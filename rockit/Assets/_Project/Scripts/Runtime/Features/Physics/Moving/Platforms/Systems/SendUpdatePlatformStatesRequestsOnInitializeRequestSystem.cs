using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SendUpdatePlatformStatesRequestsOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_psAspect.Platforms.Has(tarE)) continue;
                
                var packed = _world.PackEntityWithWorld(tarE);
                
                PlatformsMovingUtils.CreateUpdatePlatformPositionRequest(_rAspect, packed);
                PlatformsMovingUtils.CreateUpdatePlatformRotationRequest(_rAspect, packed);
                PlatformsMovingUtils.CreateUpdatePlatformScaleRequest(_rAspect, packed);
            }
        }
    }
}