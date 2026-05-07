using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public interface IPrefabPool<TItem, in TSpawnSettings, in TDespawnSettings> 
        where TItem : Component 
        where TSpawnSettings : struct
        where TDespawnSettings : struct
    {
        TItem Spawn(Transform at = null, TSpawnSettings settings = default);
        void Despawn(TItem instance, TDespawnSettings settings = default);
    }
}