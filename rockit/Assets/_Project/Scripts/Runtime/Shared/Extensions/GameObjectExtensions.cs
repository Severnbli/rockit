using _Project.Scripts.Runtime.Shared.Utils;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool TryGet<T>(this GameObject gameObject, out T component, bool logNull = true) where T : Component
        {
            component = gameObject.GetComponent<T>();

            if (component != null) return true;

            if (logNull)
            { 
                LogUtils.LogError($"Component {typeof(T).Name} not found on {gameObject.name}");
            }
            return false;
        }
    }
}