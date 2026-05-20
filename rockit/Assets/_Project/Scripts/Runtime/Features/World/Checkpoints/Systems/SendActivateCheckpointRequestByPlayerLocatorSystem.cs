using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

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
            foreach (var e in _cAspect.PlayerLocatorCheckpoints)
            {
                ref var plComponent = ref _sAspect.PlayerLocatorComponentPool.Get(e);
                if (plComponent.Distance > _cConfig.CheckDistance) continue;

                var packed = _world.PackEntityWithWorld(e);
                CheckpointsUtils.CreateActivateCheckpointRequest(_rAspect, packed);
            }
        }
    }
}