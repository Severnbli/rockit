using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public class BaseCollectionPool<T, K> : BasePool<T> where T : ICollection<K>, new()
    {
        protected override void PostDespawn(T instance)
        {
            base.PostDespawn(instance);
            
            instance.Clear();
        }
    }
}