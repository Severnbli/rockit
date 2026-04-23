using System.Collections.Generic;
using System.IO;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Shared.Utils;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Editor
{
    public class LocalizationEditorWindow : OdinEditorWindow
    {
        [MenuItem("Tools/Localization Editor")]
        private static void OpenWindow()
        {
            GetWindow<LocalizationEditorWindow>("Localization Editor").Show();
        }

        private List<LanguageData> _languages = new();
        private List<string> _allKeys = new();
        private Vector2 _scrollPos;
        private const float KeyColumnWidth = 180f;
        private const float LangColumnWidth = 160f;
        private const float RowHeight = 22f;

        protected override void OnEnable()
        {
            base.OnEnable();
            LoadFromFile();
        }

        [HorizontalGroup("Toolbar")]
        [Button("Add Language"), GUIColor(0.4f, 0.8f, 1f)]
        private void AddLanguage()
        {
            var lang = new LanguageData { LanguageCode = "new_lang" };
            foreach (var key in _allKeys) lang.Entries[key] = new LocalizationEntry { String = "" };
            _languages.Add(lang);
        }

        [HorizontalGroup("Toolbar")]
        [Button("Add Key"), GUIColor(0.6f, 1f, 0.6f)]
        private void AddKey()
        {
            const string key = "new_key";
            _allKeys.Add(key);
            foreach (var lang in _languages)
            {
                if (lang.Entries.ContainsKey(key)) continue;
                
                lang.Entries[key] = new LocalizationEntry { String = "" };
            }
        }

        [HorizontalGroup("Toolbar")]
        [Button("Save"), GUIColor(1f, 0.8f, 0.3f)]
        private void Save()
        {
            LocalizationUtils.WriteLanguageData(_languages);
            Debug.Log($"Saved to {LocalizationUtils.GetLanguageDataPath()}");
            AssetDatabase.Refresh();
        }

        [HorizontalGroup("Toolbar")]
        [Button("Reload"), GUIColor(1f, 0.5f, 0.5f)]
        private void Reload()
        {
            LoadFromFile();
        }

        [OnInspectorGUI]
        private void DrawTable()
        {
            EditorGUILayout.Space(4);

            var totalWidth = KeyColumnWidth + LangColumnWidth * _languages.Count;

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            EditorGUILayout.BeginHorizontal();
            DrawHeaderCell("Key", KeyColumnWidth);
            for (var l = 0; l < _languages.Count; l++)
            {
                _languages[l].LanguageCode = EditorGUILayout.TextField(
                    _languages[l].LanguageCode,
                    EditorStyles.boldLabel,
                    GUILayout.Width(LangColumnWidth)
                );

                if (!GUILayout.Button("✕", GUILayout.Width(18), GUILayout.Height(RowHeight))) continue;
                
                _languages.RemoveAt(l);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndScrollView();
                return;
            }
            EditorGUILayout.EndHorizontal();

            DrawSeparator(totalWidth);

            for (var r = 0; r < _allKeys.Count; r++)
            {
                EditorGUILayout.BeginHorizontal();

                EditorGUI.BeginChangeCheck();
                var newKey = EditorGUILayout.TextField(_allKeys[r], GUILayout.Width(KeyColumnWidth),
                    GUILayout.Height(RowHeight));
                
                if (EditorGUI.EndChangeCheck())
                {
                    var oldKey = _allKeys[r];
                    _allKeys[r] = newKey;
                    foreach (var lang in _languages)
                    {
                        if (!lang.Entries.Remove(oldKey, out var entry)) continue;
                        lang.Entries[newKey] = entry;
                    }
                }

                foreach (var lang in _languages)
                {
                    if (!lang.Entries.TryGetValue(_allKeys[r], out var locEntry))
                    {
                        locEntry = new LocalizationEntry { String = "" };
                        lang.Entries[_allKeys[r]] = locEntry;
                    }

                    locEntry.String = EditorGUILayout.TextField(locEntry.String, GUILayout.Width(LangColumnWidth),
                        GUILayout.Height(RowHeight));
                }

                if (GUILayout.Button("✕", GUILayout.Width(18), GUILayout.Height(RowHeight)))
                {
                    var keyToRemove = _allKeys[r];
                    _allKeys.RemoveAt(r);
                    foreach (var lang in _languages)
                        lang.Entries.Remove(keyToRemove);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndScrollView();
                    return;
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
        }

        private void DrawHeaderCell(string label, float width)
        {
            var style = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.MiddleLeft };
            GUILayout.Label(label, style, GUILayout.Width(width), GUILayout.Height(RowHeight));
        }

        private void DrawSeparator(float width)
        {
            var rect = EditorGUILayout.GetControlRect(false, 1f);
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 0.5f));
        }

        private void LoadFromFile()
        {
            var path = LocalizationUtils.GetLanguageDataPath();

            if (!File.Exists(path))
            {
                _languages = new List<LanguageData>();
                _allKeys = new List<string>();
                return;
            }

            _languages = LocalizationUtils.GetLanguageDataList();
            _allKeys = _languages
                .SelectMany(l => l.Entries.Keys)
                .Distinct()
                .ToList();
        }
    }
}