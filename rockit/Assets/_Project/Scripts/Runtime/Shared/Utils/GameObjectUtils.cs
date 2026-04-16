using System.Collections.Generic;
using System.Linq;
using ModestTree;
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

        public static bool TryGetByType<T>(out List<T> components, bool logEmpty = true) where T : Component
        {
            components = Object.FindObjectsByType<T>(FindObjectsSortMode.None).ToList();
            
            if (components.Any()) return true;

            if (logEmpty)
            {
                LogUtils.LogError($"Not found any objects of type {typeof(T)}");
            }
            return false;
        }
    }
}