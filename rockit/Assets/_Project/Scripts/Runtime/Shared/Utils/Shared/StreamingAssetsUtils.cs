using System.IO;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class StreamingAssetsUtils
    {
        public static string GetPath(string file)
        {
            return Path.Combine(Application.streamingAssetsPath, file);
        }

        public static void Write(string file, string data)
        {
            var path = GetPath(file);
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? "");
            File.WriteAllText(path, data);
        }

        public static string Read(string file)
        {
            var path = GetPath(file);
            return !File.Exists(path) ? "" : File.ReadAllText(path);
        }
    }
}