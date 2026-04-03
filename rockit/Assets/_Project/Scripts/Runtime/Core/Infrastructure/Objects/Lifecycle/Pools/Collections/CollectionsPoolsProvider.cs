using System;
using System.Collections.Generic;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class CollectionsPoolsProvider : ICollectionsPoolsProvider
    {
        protected readonly Dictionary<Type, object> Pools = new();
        protected readonly DiContainer Container;

        public CollectionsPoolsProvider(DiContainer container)
        {
            Container = container;
        }

        public TCollectionPool GetCollectionPool<TCollectionPool, TCollection, TItem>()
            where TCollectionPool : BaseCollectionPool<TCollection, TItem>
            where TCollection : ICollection<TItem>, new ()
        {
            if (Pools.TryGetValue(typeof(TCollectionPool), out var pool))
            {
                return (TCollectionPool) pool;
            }

            var poolInstance = Container.Instantiate<TCollectionPool>();
            Pools.Add(typeof(TCollectionPool), poolInstance);

            return poolInstance;
        }
    }
}