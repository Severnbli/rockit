using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class ListPool<TItem> : BaseCollectionPool<List<TItem>, TItem>
    {
        public ListPool(CollectionsPoolsConfig config) : base(config)
        {
        }

        protected override List<TItem> CreateInstance()
        {
            return new List<TItem>(Config.InitCapacity);
        }
    }
}