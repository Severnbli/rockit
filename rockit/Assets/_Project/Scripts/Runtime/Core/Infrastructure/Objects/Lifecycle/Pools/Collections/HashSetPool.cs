using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class HashSetPool<TItem> : BaseCollectionPool<HashSet<TItem>>
    {
        public HashSetPool(CollectionsPoolsConfig config) : base(config)
        {
        }

        protected override HashSet<TItem> CreateInstance()
        {
            return new HashSet<TItem>(Config.InitCapacity);
        }

        protected override void PostDespawn(HashSet<TItem> instance)
        {
            base.PreDespawn(instance);
            
            instance.Clear();
        }
    }
}