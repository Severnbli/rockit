using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public abstract class BasePrefabFactory<TItem, TSettings> : IPrefabFactory<TItem, TSettings> 
        where TItem: Component 
        where TSettings : struct
    {
        public TItem Create(Transform at = null, TSettings settings = default)
        {
            PreCreate(settings);
            var instance = CreateInstance(at, settings);
            PostCreate(instance, settings);
            return instance;
        }
        
        protected virtual void PreCreate(TSettings settings = default) {}

        protected virtual TItem CreateInstance(Transform at = null, TSettings settings = default)
        {
            if (at == null) at = FallbackContainer();
            
            var gameObject = Object.Instantiate(GetPrefab(), at);
            gameObject.TryGet(out TItem component);
            return component;
        }
        
        protected virtual void PostCreate(TItem instance, TSettings settings = default) {}

        protected abstract GameObject GetPrefab();

        protected virtual Transform FallbackContainer() => null;
    }
}