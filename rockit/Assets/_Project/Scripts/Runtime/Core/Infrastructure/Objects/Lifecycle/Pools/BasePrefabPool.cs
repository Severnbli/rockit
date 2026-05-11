using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools
{
    public abstract class BasePrefabPool<TItem, TSpawnSettings, TDespawnSettings> : BasePrefabFactory<TItem, TSpawnSettings>,
        IPrefabPool<TItem, TSpawnSettings, TDespawnSettings> 
        where TItem : Component
        where TSpawnSettings : struct
        where TDespawnSettings : struct
    {
        protected readonly Stack<GameObject> Instances = new();

        protected BasePrefabPool(ProtoWorld world) : base(world)
        {
        }

        public TItem Spawn(Transform at = null, TSpawnSettings settings = default)
        {
            PreSpawn(at, settings);
            var instance = SpawnInstance(at, settings);
            PostSpawn(instance, at, settings);
            if (TryGetEntity(instance, out var entity)) ConfigureEntityOnSpawn(instance, entity, settings);
            return instance;
        }

        protected virtual void PreSpawn(Transform at, TSpawnSettings settings = default)
        {
        }

        protected virtual TItem SpawnInstance(Transform at = null, TSpawnSettings settings = default)
        {
            if (!Instances.TryPop(out var instance)) return Create(at, settings);

            instance.TryGetComponent(out TItem component);
            instance.transform.SetParent(at == null ? FallbackContainer() : at);
            
            return component;
        }

        protected virtual void PostSpawn(TItem instance, Transform at = null, TSpawnSettings settings = default)
        {
            instance.gameObject.SetActive(true);
        }

        private bool TryGetEntity(TItem instance, out ProtoEntity entity)
        {
            entity = default;
            
            return instance.gameObject.TryGet(out ProtoUnityAuthoring authoring, false) && 
                   authoring.Entity().TryUnpackCompletely(World, out  entity);
        }

        protected virtual void ConfigureEntityOnSpawn(TItem instance, ProtoEntity entity, TSpawnSettings settings = default) {}

        public void Despawn(TItem instance, TDespawnSettings settings = default)
        {
            PreDespawn(instance, settings);
            DespawnInstance(instance, settings);
            PostDespawn(instance, settings);
            if (TryGetEntity(instance, out var entity)) ConfigureEntityOnDespawn(instance, entity, settings);
        }

        protected virtual void PreDespawn(TItem instance, TDespawnSettings settings = default)
        {
        }

        protected virtual void DespawnInstance(TItem instance, TDespawnSettings settings = default)
        {
            Instances.Push(instance.gameObject);
        }

        protected virtual void PostDespawn(TItem instance, TDespawnSettings settings = default)
        {
            instance.gameObject.SetActive(false);
        }
        
        protected virtual void ConfigureEntityOnDespawn(TItem instance, ProtoEntity entity, TDespawnSettings settings = default) {}
    }
}