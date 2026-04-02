using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public class BasePool<T> : BaseFactory<T>, IPool<T> where T : new()
    {
        protected readonly HashSet<T> Instances = new ();
        
        public T Spawn()
        {
            return Create();
        }

        public void Despawn(T instance)
        {
            ;
        }
    }
}