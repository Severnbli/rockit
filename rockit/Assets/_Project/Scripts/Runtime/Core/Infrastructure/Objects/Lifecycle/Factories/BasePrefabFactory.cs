using _Project.Scripts.Runtime.Shared.Extensions;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public class BasePrefabFactory<T> : IPrefabFactory<T> where T: Component
    {
        public T Create(Transform at = null)
        {
            PreCreate();
            var instance = CreateInstance(at);
            PostCreate(instance);
            return instance;
        }
        
        protected virtual void PreCreate() {}

        protected virtual T CreateInstance(Transform at = null)
        {
            var gameObject = Object.Instantiate(GetPrefab(), at);
            gameObject.TryGet(out T component);
            return component;
        }
        
        protected virtual void PostCreate(T instance) {}
        
        protected virtual GameObject GetPrefab()
        {
            return new GameObject();
        }
    }
}