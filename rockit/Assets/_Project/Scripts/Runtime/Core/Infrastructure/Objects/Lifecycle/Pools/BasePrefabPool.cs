using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public abstract class BasePrefabPool<T> : BasePrefabFactory<T>, IPrefabPool<T> where T : Component
    {
        public T Spawn(Transform at = null)
        {
            PreSpawn(at);
            var instance = SpawnInstance(at);
            PostSpawn(instance, at);
            return instance;
        }
        
        protected virtual void PreSpawn(Transform at) {}

        protected virtual T SpawnInstance(Transform at = null)
        {
            return Create(at);
        }
        
        protected virtual void PostSpawn(T instance, Transform at = null) {}

        public void Despawn(T instance)
        {
            PreDespawn(instance);
            DespawnInstance(instance);
            PostDespawn(instance);
        }
        
        protected virtual void PreDespawn(T instance) {}
        
        protected virtual void DespawnInstance(T instance) {}
        
        protected virtual void PostDespawn(T instance) {}
    }
}