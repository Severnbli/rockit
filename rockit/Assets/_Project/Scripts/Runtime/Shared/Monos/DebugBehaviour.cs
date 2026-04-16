using System;
using _Project.Scripts.Runtime.Shared.Tools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Monos
{
    public class DebugBehaviour : MonoBehaviour
    {
        private void Awake()
        {
#if !DEBUG
            if (Attribute.IsDefined(GetType(), typeof(DebugOnlyBehaviourAttribute))) {
                Destroy(this);
            }
#endif
            OnAwake();
        }
        
        protected virtual void OnAwake() {}
    }
}