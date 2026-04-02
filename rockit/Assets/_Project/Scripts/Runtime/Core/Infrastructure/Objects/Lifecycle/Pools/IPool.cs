namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public interface IPool<T> where T : new()
    {
        T Spawn();
        void Despawn(T instance);
    }
}