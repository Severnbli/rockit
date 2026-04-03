using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class CollectionsPoolsProvider : ICollectionsPoolsProvider
    {
        protected readonly Dictionary<Type, object> Pools = new();
        protected readonly CollectionsPoolsConfig Config;

        public CollectionsPoolsProvider(CollectionsPoolsConfig config)
        {
            Config = config;
        }

        public BaseCollectionPool<TCollection, TItem> GetCollectionPool<TCollection, TItem>()
            where TCollection : ICollection<TItem>, new()
        {
            if (Pools.TryGetValue(typeof(BaseCollectionPool<TCollection, TItem>), out var pool))
            {
                return (BaseCollectionPool<TCollection, TItem>) pool;
            }

            var poolInstance = new BaseCollectionPool<TCollection, TItem>(Config);
            Pools.Add(typeof(BaseCollectionPool<TCollection, TItem>), poolInstance);

            return poolInstance;
        }
    }
}