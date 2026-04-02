using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class LogUtils
    {
        [Conditional("DEBUG")]
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }
        
        [Conditional("DEBUG")]
        public static void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }
        
        [Conditional("DEBUG")]
        public static void LogError(string msg)
        {
            Debug.LogError(msg);
        }
    }
}