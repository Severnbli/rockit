using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public abstract class BasePrefabPool<T> : BasePrefabFactory<T>, IPrefabPool<T> where T : Component
    {
        public T Spawn(Transform at = null)
        {
            return Create(at);
        }

        public void Despawn(T instance)
        {
            ;
        }
    }
}