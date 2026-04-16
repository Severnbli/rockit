using System;
using System.Collections.Generic;
using System.Diagnostics;
using _Project.Scripts.Runtime.Shared.Utils;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Tools.Behaviour
{
    public static class BehaviourStripper
    {
#if !DEBUG
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RemoveDebugOnlyBehaviour()
        {
            GameObjectUtils.TryGetByType(out List<MonoBehaviour> behaviours, false);
            
            foreach (var b in behaviours)
            {
                var type = b.GetType();
                if (Attribute.IsDefined(type, typeof(DebugOnlyBehaviourAttribute)))
                {
                    b.enabled = false;
                }
            }
        }
#endif
    }
}