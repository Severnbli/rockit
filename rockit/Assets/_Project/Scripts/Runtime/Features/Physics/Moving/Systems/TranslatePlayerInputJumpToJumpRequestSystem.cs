using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class TranslatePlayerInputJumpToJumpRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _requestsAspect;
        [DI] private readonly SharedAspect _sharedAspect;
        private ProtoWorld _world;
        private readonly PlayerInputService _service;
        private readonly PlayerMovingConfig _config;

        public TranslatePlayerInputJumpToJumpRequestSystem(PlayerInputService service, PlayerMovingConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = _sharedAspect.World();
        }

        public void Run()
        {
            if (!_service.JumpTriggered) return;

            var prepared = new JumpRequest
            {
                Factor = _config.JumpPower
            };

            foreach (var e in _sharedAspect.Players)
            {
                var packed = _world.PackEntityWithWorld(e);
                MovingUtils.CreateJumpRequest(_requestsAspect, packed, prepared);
            }
        }
    }
}