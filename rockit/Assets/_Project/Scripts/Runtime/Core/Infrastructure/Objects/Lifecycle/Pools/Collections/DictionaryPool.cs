using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class DictionaryPool<TKey, TValue> : BaseCollectionPool<Dictionary<TKey, TValue>>
    {
        public DictionaryPool(CollectionsPoolsConfig config) : base(config)
        {
        }

        protected override Dictionary<TKey, TValue> CreateInstance()
        {
            return new Dictionary<TKey, TValue>(Config.InitCapacity);
        }

        protected override void PostDespawn(Dictionary<TKey, TValue> instance)
        {
            base.PostDespawn(instance);
            
            instance.Clear();
        }
    }
}