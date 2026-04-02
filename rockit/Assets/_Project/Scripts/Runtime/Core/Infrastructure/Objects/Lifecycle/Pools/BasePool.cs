using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public class BasePool<T> : BaseFactory<T>, IPool<T> where T : new()
    {
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