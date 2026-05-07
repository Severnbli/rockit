using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public interface IPrefabPool<TItem> where TItem : Component
    {
        TItem Spawn(Transform at = null);
        void Despawn(TItem instance);
    }
}