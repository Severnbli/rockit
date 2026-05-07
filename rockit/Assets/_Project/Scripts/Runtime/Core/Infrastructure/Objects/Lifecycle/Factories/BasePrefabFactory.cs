using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public abstract class BasePrefabFactory<TItem> : IPrefabFactory<TItem> where TItem: Component
    {
        public TItem Create(Transform at = null)
        {
            PreCreate();
            var instance = CreateInstance(at);
            PostCreate(instance);
            return instance;
        }
        
        protected virtual void PreCreate() {}

        protected virtual TItem CreateInstance(Transform at = null)
        {
            if (at == null) at = FallbackContainer();
            
            var gameObject = Object.Instantiate(GetPrefab(), at);
            gameObject.TryGet(out TItem component);
            return component;
        }
        
        protected virtual void PostCreate(TItem instance) {}

        protected abstract GameObject GetPrefab();

        protected virtual Transform FallbackContainer() => null;
    }
}