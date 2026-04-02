using _Project.Scripts.Runtime.Shared.Extensions;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public class BasePrefabFactory<T> : BaseFactory<T> where T: Component, new ()
    {
        protected override T CreateInstance()
        {
            var gameObject = GetPrefab();
            gameObject.TryGet(out T component);
            return component;
        }

        public virtual GameObject GetPrefab()
        {
            return new GameObject();
        }
    }
}