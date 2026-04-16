using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class GameObjectUtils
    {
        public static bool TryGetByType<T>(out T component, bool logNull = true) where T : Component
        {
            component = Object.FindFirstObjectByType<T>();

            if (component != null) return true;

            if (logNull)
            {
                LogUtils.LogError($"Not found object of type {typeof(T)}");
            }
            return false;
        }
    }
}