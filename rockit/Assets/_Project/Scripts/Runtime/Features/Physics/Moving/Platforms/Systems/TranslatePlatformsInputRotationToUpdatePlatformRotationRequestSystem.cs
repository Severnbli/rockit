using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class TranslatePlatformsInputRotationToUpdatePlatformRotationRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private readonly PlatformsInputService _piService;
        private ProtoWorld _world;

        public TranslatePlatformsInputRotationToUpdatePlatformRotationRequestSystem(PlatformsInputService piService)
        {
            _piService = piService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            if (!_piService.RotationTriggered) return;

            foreach (var e in _psAspect.Platforms)
            {
                var packed = _world.PackEntityWithWorld(e);
                PlatformsMovingUtils.CreateUpdatePlatformRotationRequest(_rAspect, packed);
            }
        }
    }
}