using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class BaseCollectionPool<TCollection, TItem> : BasePool<TCollection> where TCollection : ICollection<TItem>, new()
    {
        protected readonly CollectionsPoolsConfig Config;

        public BaseCollectionPool(CollectionsPoolsConfig config)
        {
            Config = config;
        }

        protected override void PostDespawn(TCollection instance)
        {
            base.PostDespawn(instance);
            
            instance.Clear();
        }
    }
}