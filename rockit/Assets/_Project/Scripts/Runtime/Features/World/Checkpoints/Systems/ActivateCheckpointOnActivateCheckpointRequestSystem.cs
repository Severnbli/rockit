using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.World;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints.Systems
{
    public sealed class ActivateCheckpointOnActivateCheckpointRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly CheckpointsRequestsAspect _crAspect;
        [DI] private readonly CheckpointsAspect _cAspect;
        private readonly CheckpointsService _cService;
        private ProtoWorld _world;

        public ActivateCheckpointOnActivateCheckpointRequestSystem(CheckpointsService cService)
        {
            _cService = cService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _crAspect.ActivateCheckpointRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cAspect.Checkpoints.Has(tarE)) continue;

                ref var cComponent = ref _cAspect.CheckpointComponentPool.Get(tarE);
                if (_cService.LastCheckpoint == cComponent.Checkpoint) continue;
                
                _cService.ExpireLast();
                _cService.LastCheckpoint = cComponent.Checkpoint;

                _cAspect.ActiveCheckpointTagPool.GetOrAdd(tarE);
                return;
            }
        }
    }
}