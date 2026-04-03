using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class StackPool<TItem> : BaseCollectionPool<Stack<TItem>>
    {
        public StackPool(CollectionsPoolsConfig config) : base(config)
        {
        }

        protected override Stack<TItem> CreateInstance()
        {
            return new Stack<TItem>(Config.InitCapacity);
        }

        protected override void PostDespawn(Stack<TItem> instance)
        {
            base.PostDespawn(instance);
            
            instance.Clear();
        }
    }
}