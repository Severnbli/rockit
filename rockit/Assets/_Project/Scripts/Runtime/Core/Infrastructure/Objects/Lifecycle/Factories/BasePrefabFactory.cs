using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Tags;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories
{
    public abstract class BasePrefabFactory<TItem, TSettings> : IPrefabFactory<TItem, TSettings> 
        where TItem: Component 
        where TSettings : struct
    {
        protected readonly ProtoWorld World;

        protected BasePrefabFactory(ProtoWorld world)
        {
            World = world;
        }

        public TItem Create(Transform at = null, TSettings settings = default)
        {
            PreCreate(settings);
            var instance = CreateInstance(at, settings);
            PostCreate(instance, settings);
            InitiateAuthoring(instance, settings);
            
            return instance;
        }
        
        protected virtual void PreCreate(TSettings settings = default) {}

        protected virtual TItem CreateInstance(Transform at = null, TSettings settings = default)
        {
            if (at == null) at = FallbackContainer();
            
            var gameObject = Object.Instantiate(GetPrefab(), at);
            gameObject.TryGet(out TItem component);
            return component;
        }
        
        protected virtual void PostCreate(TItem instance, TSettings settings = default) {}

        private void InitiateAuthoring(TItem instance, TSettings settings = default)
        {
            if (!instance.gameObject.TryGet(out ProtoUnityAuthoring authoring, false)) return;

            Pool<CreatedAtFactoryTag>().NewEntity(out var entity);
            authoring.ProcessAuthoringForEntity(World, entity);
            ConfigureEntityOnCreate(instance, entity, settings);
        }
        
        protected ProtoPool<T> Pool<T>() where T : struct => World.GetPool<T>();
        
        protected virtual void ConfigureEntityOnCreate(TItem instance, ProtoEntity entity, TSettings settings = default) {}

        protected abstract GameObject GetPrefab();

        protected virtual Transform FallbackContainer() => null;
    }
}