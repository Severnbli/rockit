using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public class BasePool<T> : BaseFactory<T>, IPool<T> where T : new()
    {
        protected readonly HashSet<T> Instances = new ();
        
        public T Spawn()
        {
            PreSpawn();
            var instance = SpawnInstance();
            PostSpawn(instance);
            return instance;
        }
        
        protected virtual void PreSpawn() {}

        protected virtual T SpawnInstance()
        {
            return Create();
        }
        
        protected virtual void PostSpawn(T instance) {}

        public void Despawn(T instance)
        {
            ;
        }
    }
}