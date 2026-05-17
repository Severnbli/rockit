using System.IO;
using Cysharp.Threading.Tasks;
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
            FilesUtils.Write(path, data);
        }

        public static string Read(string file)
        {
            var path = GetPath(file);
            return FilesUtils.Read(path);
        }
        
        public static async UniTask<string> ReadAsync(string file)
        {
            var path = GetPath(file);
            return await WebUtils.GetText(path);
        }
    }
}