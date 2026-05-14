using System.Collections.Generic;
using System.IO;
using System.Linq;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Editor
{
    public class LocalizationEditorWindow : OdinEditorWindow
    {
        private class EditorRow
        {
            public string Key;
            public List<string> Values = new();
        }

        [MenuItem("Tools/Localization Editor")]
        private static void OpenWindow()
        {
            GetWindow<LocalizationEditorWindow>("Localization Editor").Show();
        }

        private List<string> _languageCodes = new();
        private List<EditorRow> _rows = new();

        private Vector2 _scrollPos;
        private const float KeyColumnWidth = 180f;
        private const float LangColumnWidth = 160f;
        private const float RowHeight = 22f;
        private const float HandleWidth = 16f;

        private int _dragSourceIndex = -1;
        private int _dragTargetIndex = -1;
        private float _scrollContentOriginY;

        protected override void OnEnable()
        {
            base.OnEnable();
            LoadFromFile();
        }

        [HorizontalGroup("Toolbar")]
        [Button("Add Language"), GUIColor(0.4f, 0.8f, 1f)]
        private void AddLanguage()
        {
            _languageCodes.Add("new_lang");
            foreach (var row in _rows)
                row.Values.Add("");
        }

        [HorizontalGroup("Toolbar")]
        [Button("Add Key"), GUIColor(0.6f, 1f, 0.6f)]
        private void AddKey()
        {
            var key = "new_key";
            if (_rows.Any(r => r.Key == key))
            {
                var i = 1;
                while (_rows.Any(r => r.Key == $"new_key_{i}")) i++;
                key = $"new_key_{i}";
            }

            _rows.Add(new EditorRow
            {
                Key = key,
                Values = Enumerable.Repeat("", _languageCodes.Count).ToList()
            });
        }

        [HorizontalGroup("Toolbar")]
        [Button("Save"), GUIColor(1f, 0.8f, 0.3f)]
        private void Save()
        {
            LocalizationUtils.WriteLanguageData(BuildLanguageData());
            Debug.Log($"Saved to {LocalizationUtils.GetLanguageDataPath()}");
            AssetDatabase.Refresh();
        }

        [HorizontalGroup("Toolbar")]
        [Button("Reload"), GUIColor(1f, 0.5f, 0.5f)]
        private void Reload() => LoadFromFile();

        [OnInspectorGUI]
        private void DrawTable()
        {
            EditorGUILayout.Space(4);

            var duplicateKeys = _rows
                .GroupBy(r => r.Key)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToHashSet();

            var warningStyle = new GUIStyle(EditorStyles.helpBox)
            {
                normal = { textColor = new Color(1f, 0.75f, 0.2f) },
                fontStyle = FontStyle.Bold,
                fontSize = 11,
            };

            EditorGUILayout.LabelField(
                duplicateKeys.Count > 0
                    ? $"⚠  Duplicate keys: {string.Join(", ", duplicateKeys.Select(k => $"\"{k}\""))}"
                    : " ",
                warningStyle);
            EditorGUILayout.Space(2);

            var totalWidth = HandleWidth + KeyColumnWidth + LangColumnWidth * _languageCodes.Count;

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(HandleWidth);
            DrawHeaderCell("Key", KeyColumnWidth);

            for (var l = 0; l < _languageCodes.Count; l++)
            {
                _languageCodes[l] = EditorGUILayout.TextField(
                    _languageCodes[l],
                    EditorStyles.boldLabel,
                    GUILayout.Width(LangColumnWidth));

                if (!GUILayout.Button("✕", GUILayout.Width(18), GUILayout.Height(RowHeight))) continue;

                _languageCodes.RemoveAt(l);
                foreach (var row in _rows) row.Values.RemoveAt(l);

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndScrollView();
                return;
            }

            EditorGUILayout.EndHorizontal();
            DrawSeparator(totalWidth);

            var captureOrigin = Event.current.type == EventType.Repaint;

            for (var r = 0; r < _rows.Count; r++)
            {
                if (_dragSourceIndex >= 0 && _dragTargetIndex == r)
                    DrawDropIndicator(totalWidth);

                var row = _rows[r];
                EditorGUILayout.BeginHorizontal();

                var handleRect = GUILayoutUtility.GetRect(
                    HandleWidth, RowHeight,
                    GUILayout.Width(HandleWidth), GUILayout.Height(RowHeight));

                if (captureOrigin && r == 0)
                    _scrollContentOriginY = handleRect.y;

                DrawHandle(handleRect, r);

                var isDuplicate = duplicateKeys.Contains(row.Key);
                var originalBg = GUI.backgroundColor;
                if (isDuplicate) GUI.backgroundColor = new Color(1f, 0.4f, 0.4f);

                var controlName = $"key_{r}";
                GUI.SetNextControlName(controlName);
                EditorGUI.BeginChangeCheck();

                var newKey = EditorGUILayout.TextField(row.Key,
                    GUILayout.Width(KeyColumnWidth), GUILayout.Height(RowHeight));

                GUI.backgroundColor = originalBg;

                if (EditorGUI.EndChangeCheck())
                {
                    row.Key = newKey;
                    GUI.FocusControl(controlName);
                }

                for (var l = 0; l < _languageCodes.Count; l++)
                {
                    while (row.Values.Count <= l) row.Values.Add("");
                    row.Values[l] = EditorGUILayout.TextField(row.Values[l],
                        GUILayout.Width(LangColumnWidth), GUILayout.Height(RowHeight));
                }

                if (GUILayout.Button("✕", GUILayout.Width(18), GUILayout.Height(RowHeight)))
                {
                    _rows.RemoveAt(r);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndScrollView();
                    return;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (_dragSourceIndex >= 0 && _dragTargetIndex == _rows.Count)
                DrawDropIndicator(totalWidth);

            EditorGUILayout.EndScrollView();

            HandleDragEvents();
        }

        private void DrawHandle(Rect rect, int rowIndex)
        {
            var isBeingDragged = _dragSourceIndex == rowIndex;
            var handleStyle = new GUIStyle(EditorStyles.label)
            {
                alignment = TextAnchor.MiddleCenter,
                normal = { textColor = isBeingDragged ? new Color(0.4f, 0.7f, 1f) : new Color(0.6f, 0.6f, 0.6f) },
                fontSize = 13,
            };

            EditorGUIUtility.AddCursorRect(rect, MouseCursor.Pan);
            GUI.Label(rect, "⠿", handleStyle);

            var e = Event.current;
            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition) && e.button == 0)
            {
                _dragSourceIndex = rowIndex;
                _dragTargetIndex = rowIndex;
                _scrollContentOriginY = rect.y - rowIndex * RowHeight;
                e.Use();
            }
        }

        private void DrawDropIndicator(float totalWidth)
        {
            var rect = EditorGUILayout.GetControlRect(false, 2f);
            EditorGUI.DrawRect(rect, new Color(0.3f, 0.6f, 1f, 0.9f));
        }

        private void HandleDragEvents()
        {
            if (_dragSourceIndex < 0) return;

            var e = Event.current;

            switch (e.type)
            {
                case EventType.MouseDrag:
                {
                    var localY = e.mousePosition.y - _scrollContentOriginY;
                    _dragTargetIndex = Mathf.Clamp(
                        Mathf.RoundToInt(localY / RowHeight),
                        0,
                        _rows.Count);
                    Repaint();
                    e.Use();
                    break;
                }

                case EventType.MouseUp:
                    CommitDrop();
                    e.Use();
                    break;

                case EventType.MouseLeaveWindow:
                    CancelDrag();
                    break;
            }
        }

        private void CommitDrop()
        {
            var src = _dragSourceIndex;
            var dst = _dragTargetIndex;

            if (src >= 0 && src < _rows.Count && dst != src && dst != src + 1)
            {
                var row = _rows[src];
                _rows.RemoveAt(src);
                if (dst > src) dst--;
                _rows.Insert(dst, row);
            }

            CancelDrag();
            Repaint();
        }

        private void CancelDrag()
        {
            _dragSourceIndex = -1;
            _dragTargetIndex = -1;
        }

        private void DrawHeaderCell(string label, float width)
        {
            var style = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.MiddleLeft };
            GUILayout.Label(label, style, GUILayout.Width(width), GUILayout.Height(RowHeight));
        }

        private void DrawSeparator(float totalWidth)
        {
            var rect = EditorGUILayout.GetControlRect(false, 1f);
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 0.5f));
        }

        private void LoadFromFile()
        {
            var path = LocalizationUtils.GetLanguageDataPath();

            if (!File.Exists(path))
            {
                _languageCodes = new List<string>();
                _rows = new List<EditorRow>();
                return;
            }

            var languages = LocalizationUtils.GetLanguageDataList();
            _languageCodes = languages.Select(l => l.LanguageCode).ToList();

            var allKeys = languages.SelectMany(l => l.Entries.Keys).Distinct().ToList();

            _rows = allKeys.Select(key => new EditorRow
            {
                Key = key,
                Values = _languageCodes.Select((_, langIndex) =>
                {
                    var lang = languages[langIndex];
                    return lang.Entries.TryGetValue(key, out var entry) ? entry.String : "";
                }).ToList()
            }).ToList();
        }

        private List<LanguageData> BuildLanguageData()
        {
            var result = _languageCodes
                .Select(code => new LanguageData { LanguageCode = code })
                .ToList();

            foreach (var row in _rows)
                for (var l = 0; l < result.Count; l++)
                    result[l].Entries[row.Key] = new LocalizationEntry
                    {
                        String = l < row.Values.Count ? row.Values[l] : ""
                    };

            return result;
        }
    }
}