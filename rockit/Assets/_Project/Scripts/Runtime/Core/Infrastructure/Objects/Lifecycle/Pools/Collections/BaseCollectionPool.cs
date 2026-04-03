using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class BaseCollectionPool<T, K> : BasePool<T> where T : ICollection<K>, new()
    {
        protected readonly CollectionsPoolsConfig Config;

        public BaseCollectionPool(CollectionsPoolsConfig config)
        {
            Config = config;
        }

        protected override void PostDespawn(T instance)
        {
            base.PostDespawn(instance);
            
            instance.Clear();
        }
    }
}