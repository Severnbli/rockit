using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class TranslatePlatformsInputPositionToUpdatePlatformPositionRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private readonly PlatformsInputService _piService;
        private ProtoWorld _world;

        public TranslatePlatformsInputPositionToUpdatePlatformPositionRequestSystem(PlatformsInputService piService)
        {
            _piService = piService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            if (!_piService.PositionTriggered) return;

            foreach (var e in _psAspect.Platforms)
            {
                var packed = _world.PackEntityWithWorld(e);
                PlatformsMovingUtils.CreateUpdatePlatformPositionRequest(_rAspect, packed);
            }
        }
    }
}