using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using ObjectFieldAlignment = Sirenix.OdinInspector.ObjectFieldAlignment;

namespace _Project.Scripts.Editor
{
    public class AnimatorControllerGeneratorWindow : OdinEditorWindow
    {
        [MenuItem("Tools/Animator Controller Generator")]
        private static void OpenWindow()
        {
            var window = GetWindow<AnimatorControllerGeneratorWindow>();
            window.titleContent = new GUIContent("AC Generator",
                EditorGUIUtility.IconContent("AnimatorController Icon").image);
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(520, 600);
        }
 
        public enum Tab { Create, Edit }
 
        [HideLabel, EnumToggleButtons, PropertyOrder(-10)]
        public Tab ActiveTab = Tab.Create;
 
        [ShowIf("@ActiveTab == Tab.Create")]
        [FolderPath(RequireExistingPath = true)]
        [LabelText("Save Folder")]
        public string OutputFolder = "Assets";
 
        [ShowIf("@ActiveTab == Tab.Create")]
        [LabelText("Controller Name")]
        public string ControllerName = "Controller";
 
        [ShowIf("@ActiveTab == Tab.Create")]
        [LabelText("Clip Names")]
        [ListDrawerSettings(
            ShowFoldout = false,
            DraggableItems = true,
            ShowPaging = false,
            CustomAddFunction = nameof(AddClipName))]
        public List<string> ClipNames = new () { "First", "Second", "Third" };
 
        [ShowIf("@ActiveTab == Tab.Create")]
        [Button(ButtonSizes.Large, Name = "Create Animator Controller"), GUIColor(0.35f, 0.8f, 0.45f)]
        [PropertyOrder(100)]
        private void CreateController()
        {
            if (string.IsNullOrWhiteSpace(ControllerName))
            {
                EditorUtility.DisplayDialog("Error", "Controller name cannot be empty.", "OK");
                return;
            }
 
            if (ClipNames.Count == 0)
            {
                EditorUtility.DisplayDialog("Error", "Add at least one clip.", "OK");
                return;
            }
 
            string path = Path.Combine(OutputFolder, ControllerName.Trim() + ".controller");
            path = AssetDatabase.GenerateUniqueAssetPath(path);
 
            var controller = AnimatorController.CreateAnimatorControllerAtPath(path);
 
            while (controller.layers.Length > 0)
                controller.RemoveLayer(0);
 
            controller.AddLayer("Base Layer");
 
            foreach (string clipName in ClipNames)
            {
                if (string.IsNullOrWhiteSpace(clipName)) continue;
                EmbedClip(controller, clipName.Trim());
            }
 
            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
 
            Selection.activeObject = controller;
            EditorGUIUtility.PingObject(controller);
        }
 
        private string AddClipName() => $"Clip{ClipNames.Count}";
 
        [ShowIf("@ActiveTab == Tab.Edit")]
        [Required]
        [InlineButton(nameof(LoadController), "Load")]
        [AssetSelector(Filter = "t:AnimatorController")]
        [OnValueChanged(nameof(LoadController))]
        [LabelText("Controller")]
        public AnimatorController TargetController;
 
        [ShowIf("@ActiveTab == Tab.Edit && TargetController != null")]
        [LabelText("New Clip Name")]
        [HorizontalGroup("AddClipRow", Width = 0.7f), HideLabel]
        public string NewClipName = "";
 
        [ShowIf("@ActiveTab == Tab.Edit && TargetController != null")]
        [HorizontalGroup("AddClipRow")]
        [Button("Add Clip"), GUIColor(0.35f, 0.8f, 0.45f)]
        private void AddClipToExisting()
        {
            if (TargetController == null) return;
            if (string.IsNullOrWhiteSpace(NewClipName))
            {
                EditorUtility.DisplayDialog("Error", "Clip name cannot be empty.", "OK");
                return;
            }
 
            EmbedClip(TargetController, NewClipName.Trim());
            EditorUtility.SetDirty(TargetController);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
 
            NewClipName = "";
            LoadController();
        }
 
        [ShowIf("@ActiveTab == Tab.Edit && TargetController != null")]
        [LabelText("Embedded Clips")]
        [ListDrawerSettings(
            ShowFoldout = false,
            DraggableItems = false,
            HideAddButton = true,
            ShowPaging = false,
            OnBeginListElementGUI = nameof(BeginClipElement),
            OnEndListElementGUI = nameof(EndClipElement))]
        [PropertyOrder(50)]
        public List<ClipEntry> EmbeddedClips = new ();
 
        private void BeginClipElement(int index) { }
        private void EndClipElement(int index) { }
 
        private void LoadController()
        {
            EmbeddedClips.Clear();
            if (TargetController == null) return;
 
            var assetPath = AssetDatabase.GetAssetPath(TargetController);
            foreach (var asset in AssetDatabase.LoadAllAssetsAtPath(assetPath))
            {
                if (asset is AnimationClip clip && !clip.name.StartsWith("__preview__"))
                    EmbeddedClips.Add(new ClipEntry { Clip = clip, Name = clip.name });
            }
        }
 
        [ShowIf("@ActiveTab == Tab.Edit && EmbeddedClips.Count > 0")]
        [Button(ButtonSizes.Large, Name = "Apply Renames"), GUIColor(0.35f, 0.6f, 1f)]
        [PropertyOrder(60)]
        private void ApplyRenames()
        {
            if (TargetController == null) return;
            bool changed = false;
 
            foreach (var entry in EmbeddedClips)
            {
                if (entry.Clip == null) continue;
                var trimmed = entry.Name?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(trimmed)) continue;
                if (entry.Clip.name == trimmed) continue;
 
                entry.Clip.name = trimmed;
                EditorUtility.SetDirty(entry.Clip);
                changed = true;
            }
 
            if (changed)
            {
                EditorUtility.SetDirty(TargetController);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                LoadController();
            }
        }
 
        [ShowIf("@ActiveTab == Tab.Edit && EmbeddedClips.Count > 0")]
        [Button(ButtonSizes.Medium, Name = "Remove Selected Clips"), GUIColor(1f, 0.4f, 0.4f)]
        [PropertyOrder(70)]
        private void RemoveSelectedClips()
        {
            if (TargetController == null) return;
            var toRemove = EmbeddedClips.Where(e => e.Selected && e.Clip != null).ToList();
            if (toRemove.Count == 0)
            {
                EditorUtility.DisplayDialog("Nothing selected", "Check the boxes next to clips you want to remove.", "OK");
                return;
            }
 
            var confirm = EditorUtility.DisplayDialog(
                "Remove Clips",
                $"Remove {toRemove.Count} clip(s) from the controller?\nThis cannot be undone.",
                "Remove", "Cancel");
 
            if (!confirm) return;
 
            foreach (var entry in toRemove)
            {
                AssetDatabase.RemoveObjectFromAsset(entry.Clip);
                DestroyImmediate(entry.Clip, true);
            }
 
            EditorUtility.SetDirty(TargetController);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            LoadController();
        }
 
        [MenuItem("Assets/Open in AC Generator", true)]
        private static bool ValidateOpenInGenerator() =>
            Selection.activeObject is AnimatorController;
 
        [MenuItem("Assets/Open in AC Generator")]
        private static void OpenInGenerator()
        {
            var window = GetWindow<AnimatorControllerGeneratorWindow>();
            window.ActiveTab        = Tab.Edit;
            window.TargetController = Selection.activeObject as AnimatorController;
            window.LoadController();
            window.Focus();
        }
 
        private static AnimationClip EmbedClip(AnimatorController controller, string clipName)
        {
            var clip = new AnimationClip { name = clipName };
            AssetDatabase.AddObjectToAsset(clip, controller);
            return clip;
        }
    }
 
    [Serializable]
    public class ClipEntry
    {
        [HorizontalGroup("Row", Width = 20), HideLabel, ToggleLeft]
        public bool Selected;
 
        [HorizontalGroup("Row", Width = 36), HideLabel, PreviewField(32, ObjectFieldAlignment.Left), ReadOnly]
        public AnimationClip Clip;
 
        [HorizontalGroup("Row"), HideLabel]
        public string Name;
    }
}