namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections
{
    public class BaseCollectionPool<TCollection> : BasePool<TCollection> where TCollection : new()
    {
        protected readonly CollectionsPoolsConfig Config;

        public BaseCollectionPool(CollectionsPoolsConfig config)
        {
            Config = config;
        }
    }
}