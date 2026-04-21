using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public class UpdateBufferOnUpdatePlatformRotationRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsMovingRequestsAspect _pmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _pmrAspect.UpdatePlatformRotationRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_psAspect.Platforms.Has(tarE)) continue;

                ref var pubComponent = ref _pmAspect.PlatformUpdatesBufferComponentPool.GetOrAdd(tarE);
                pubComponent.RotationUpdates++;
            }
        }
    }
}