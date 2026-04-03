using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class CollectionsPoolsProvider : ICollectionsPoolsProvider
    {
        protected readonly Dictionary<Type, object> Pools = new();
        
        public BaseCollectionPool<TCollection, TItem> GetCollectionPool<TCollection, TItem>() where TCollection : ICollection<TItem>, new()
        protected readonly CollectionsPoolsConfig Config;

        public CollectionsPoolsProvider(CollectionsPoolsConfig config)
        {
            Config = config;
        }
        {
            return null;
        }
    }
}