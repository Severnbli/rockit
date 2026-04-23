using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class LocalizationUtils
    {
        private const string LanguageDataFileName = "localizations";
        
        public static string GetLanguageDataPath()
        {
            return System.IO.Path.Combine(Application.streamingAssetsPath, $"{LanguageDataFileName}.json");
        }

        public static void WriteLanguageData(string json)
        {
            var path = GetLanguageDataPath();
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path) ?? "");
            System.IO.File.WriteAllText(path, json);
        }

        public static string GetLanguageData()
        {
            var path = GetLanguageDataPath();
            return !System.IO.File.Exists(path) ? "" : System.IO.File.ReadAllText(path);
        }
    }
}