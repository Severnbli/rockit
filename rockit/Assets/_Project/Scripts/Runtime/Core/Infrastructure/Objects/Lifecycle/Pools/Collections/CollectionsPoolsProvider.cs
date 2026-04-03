using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class CollectionsPoolsProvider : ICollectionsPoolsProvider
    {
        public BaseCollectionPool<TCollection, TItem> GetCollectionPool<TCollection, TItem>() where TCollection : ICollection<TItem>, new()
        {
            return null;
        }
    }
}