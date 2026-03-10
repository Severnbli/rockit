// Script was taken here: https://odininspector.com/community-tools/540/scriptableobject-creator

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Editor
{
    public class ScriptableObjectCreator : OdinMenuEditorWindow
    {
        private static readonly HashSet<Type> ScriptableObjectTypes = AssemblyUtilities
            .GetTypes(AssemblyCategory.Scripts)
            .Where(t =>
                t.IsClass &&
                typeof(ScriptableObject).IsAssignableFrom(t) &&
                !typeof(EditorWindow).IsAssignableFrom(t) &&
                !typeof(UnityEditor.Editor).IsAssignableFrom(t))
            .ToHashSet();

        private ScriptableObject _previewObject;
        private Vector2 _scroll;
        private string _targetFolder;

        private Type SelectedType
        {
            get
            {
                var m = MenuTree.Selection.LastOrDefault();
                return m == null ? null : m.Value as Type;
            }
        }

        [MenuItem("Assets/Create Scriptable Object", priority = -1000)]
        private static void ShowDialog()
        {
            var path = "Assets";
            var obj = Selection.activeObject;
            if (obj && AssetDatabase.Contains(obj))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!Directory.Exists(path)) path = Path.GetDirectoryName(path);
            }

            var window = CreateInstance<ScriptableObjectCreator>();
            window.ShowUtility();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
            window.titleContent = new GUIContent(path);

            if (path != null) window._targetFolder = path.Trim('/');
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            MenuWidth = 270;
            WindowPadding = Vector4.zero;

            var tree = new OdinMenuTree(false)
            {
                Config =
                {
                    DrawSearchToolbar = true
                },
                DefaultMenuStyle = OdinMenuStyle.TreeViewStyle
            };

            tree.AddRange(ScriptableObjectTypes.Where(x => !x.IsAbstract), GetMenuPathForType).AddThumbnailIcons();
            tree.SortMenuItemsByName();
            tree.Selection.SelectionConfirmed += x => CreateAsset();
            tree.Selection.SelectionChanged += e =>
            {
                if (_previewObject && !AssetDatabase.Contains(_previewObject)) DestroyImmediate(_previewObject);

                if (e != SelectionChangedType.ItemAdded) return;

                var t = SelectedType;
                if (t is { IsAbstract: false }) _previewObject = CreateInstance(t);
            };

            return tree;
        }

        private string GetMenuPathForType(Type t)
        {
            if (t == null || !ScriptableObjectTypes.Contains(t)) return "";
            
            var name = t.Name.Split('`').First().SplitPascalCase();
            return GetMenuPathForType(t.BaseType) + "/" + name;

        }

        protected override IEnumerable<object> GetTargets()
        {
            yield return _previewObject;
        }

        protected override void DrawEditor(int index)
        {
            _scroll = GUILayout.BeginScrollView(_scroll);
            {
                base.DrawEditor(index);
            }
            GUILayout.EndScrollView();

            if (_previewObject)
            {
                GUILayout.FlexibleSpace();
                SirenixEditorGUI.HorizontalLineSeparator();
                if (GUILayout.Button("Create Asset", GUILayoutOptions.Height(30))) CreateAsset();
            }
        }

        private void CreateAsset()
        {
            if (_previewObject)
            {
                var dest = _targetFolder + "/" + MenuTree.Selection.First().Name.Replace(" ", "") + ".asset";
                dest = AssetDatabase.GenerateUniqueAssetPath(dest);
                AssetDatabase.CreateAsset(_previewObject, dest);
                AssetDatabase.Refresh();
                Selection.activeObject = _previewObject;
                EditorApplication.delayCall += Close;
            }
        }
    }
}