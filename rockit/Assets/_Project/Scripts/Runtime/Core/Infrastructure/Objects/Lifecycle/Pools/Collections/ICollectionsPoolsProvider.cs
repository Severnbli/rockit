using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public interface ICollectionsPoolsProvider
    {
        TCollectionPool GetCollectionPool<TCollectionPool, TCollection, TItem>()
            where TCollectionPool: BaseCollectionPool<TCollection, TItem>
            where TCollection : ICollection<TItem>, new ();
    }
}