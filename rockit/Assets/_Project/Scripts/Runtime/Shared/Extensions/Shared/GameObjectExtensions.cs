using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Leopotam.EcsProto.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
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

        public static bool TryGetComponentWithCache<T>(this GameObject go, Dictionary<Type, Component> goCache,
            out T component) 
            where T : Component
        {
            component = null;
            
            if (!goCache.TryGetValue(typeof(T), out var cachedComponent))
            {
                if (!go.TryGet(out component)) return false;
                
                goCache[typeof(T)] = component;
                return true;
            }
            
            try
            {
                component = (T) cachedComponent;
            }
            catch (Exception)
            {
                LogUtils.LogError($"Failed to cast value from {go.name} cache to {typeof(T).Name} type");
                return false;
            }
            
            return true;
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

        public static bool TryGetChildrenComponents<T>(this GameObject gameObject, out List<T> components,
            bool logEmpty = true) 
            where T : Component
        {
            components = gameObject.GetComponentsInChildren<T>().Where(x => x.gameObject != gameObject).ToList();

            if (components.Any())
            {
                return true;
            }

            if (logEmpty)
            {
                LogUtils.LogWarning($"Components of type {typeof(T).Name} not found in children {gameObject.name}");
            }
            return false;
        }

        public static List<T> GetChildrenComponents<T>(this GameObject gameObject) 
            where T : Component
        {
            TryGetChildrenComponents<T>(gameObject, out var components, false);
            return components;
        }

        public static void RemoveChildren(this GameObject gameObject)
        {
            foreach (Transform tf in gameObject.transform)
            {
                Object.Destroy(tf.gameObject);
            }
        }
    }
}