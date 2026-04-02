using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public interface IPrefabPool<T> where T : Component
    {
        T Spawn(Transform at = null);
        void Despawn(T instance);
    }
}