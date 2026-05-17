using System.IO;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class FilesUtils
    {
        public static void Write(string path, string data)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? "");
            File.WriteAllText(path, data);
        }

        public static string Read(string path)
        {
            return !File.Exists(path) ? "" : File.ReadAllText(path);
        }
    }
}