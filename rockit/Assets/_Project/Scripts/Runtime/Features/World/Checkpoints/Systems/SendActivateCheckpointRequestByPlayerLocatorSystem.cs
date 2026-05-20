using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Systems
{
    public sealed class SendActivateCheckpointRequestByPlayerLocatorSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly CheckpointsAspect _cAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly CheckpointsConfig _cConfig;
        private ProtoWorld _world;

        public SendActivateCheckpointRequestByPlayerLocatorSystem(CheckpointsConfig cConfig)
        {
            _cConfig = cConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            ProtoEntity entity = default;
            var minDistance = Mathf.Infinity;
            
            foreach (var e in _cAspect.PlayerLocatorCheckpoints)
            {
                ref var plComponent = ref _sAspect.PlayerLocatorComponentPool.Get(e);
                var distance = plComponent.Distance;
                
                if (distance > _cConfig.CheckDistance || distance > minDistance) continue;
                
                minDistance = distance;
                entity = e;
            }
            if (entity == default) return;
            
            var packed = _world.PackEntityWithWorld(entity);
            CheckpointsUtils.CreateActivateCheckpointRequest(_rAspect, packed);
        }
    }
}