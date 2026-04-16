using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto.Unity;
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

        public static bool TryGetAuthored<T>(this GameObject gameObject, out T authored, bool logNull = true)
            where T : struct
        {
            authored = default;
            
            if (!gameObject.TryGet(out ProtoUnityAuthoring authoring))
            {
                LogUtils.LogWarning($"Object {gameObject.name} is not authored");
                return false;
            }

            foreach (var c in authoring.Components)
            {
                if (c is not T t) continue;
                
                authored = t;
                return true;
            }

            if (logNull)
            {
                LogUtils.LogWarning($"Authored {typeof(T).Name} not found on {gameObject.name}");
            }
            
            return false;
        }
    }
}