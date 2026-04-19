using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class GameObjectIndexUpdateSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        private readonly SharedIndexService _siService;
        private readonly HashSetPool<GameObject> _gosPool;
        private ProtoWorld _world;

        public GameObjectIndexUpdateSystem(SharedIndexService siService, IObjectDomain domain)
        {
            _siService = siService;
            domain.Get(out _gosPool);
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var set = _gosPool.Spawn();
            
            foreach (var e in _sAspect.IndexableGameObjects)
            {
                ref var goComponent = ref _sAspect.GameObjectComponentPool.Get(e);
                set.Add(goComponent.GameObject);

                var packed = _world.PackEntityWithWorld(e);
                _siService.GameObjectIndex.UpdateOrAdd(goComponent.GameObject, packed);
            }
            
            _siService.GameObjectIndex.KeepOnly(set);
            _gosPool.Despawn(set);
        }
    }
}