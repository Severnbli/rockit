using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public abstract class BasePrefabPool<TItem> : BasePrefabFactory<TItem>, IPrefabPool<TItem> where TItem : Component
    {
        protected readonly Stack<GameObject> Instances = new ();
        
        public TItem Spawn(Transform at = null)
        {
            PreSpawn(at);
            var instance = SpawnInstance(at);
            PostSpawn(instance, at);
            return instance;
        }
        
        protected virtual void PreSpawn(Transform at) {}

        protected virtual TItem SpawnInstance(Transform at = null)
        {
            if (!Instances.TryPop(out var instance)) return Create(at);
            
            instance.TryGetComponent(out TItem component);
            return component;
        }

        protected virtual void PostSpawn(TItem instance, Transform at = null)
        {
            instance.gameObject.SetActive(true);
        }

        public void Despawn(TItem instance)
        {
            PreDespawn(instance);
            DespawnInstance(instance);
            PostDespawn(instance);
        }
        
        protected virtual void PreDespawn(TItem instance) {}

        protected virtual void DespawnInstance(TItem instance)
        {
            Instances.Push(instance.gameObject);
        }

        protected virtual void PostDespawn(TItem instance)
        {
            instance.gameObject.SetActive(false);
        }
    }
}