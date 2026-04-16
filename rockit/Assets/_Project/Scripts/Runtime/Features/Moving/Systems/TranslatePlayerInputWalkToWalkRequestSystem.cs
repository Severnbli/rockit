using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Moving.Configs;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class TranslatePlayerInputWalkToWalkRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _requestsAspect;
        [DI] private readonly SharedAspect _sharedAspect;
        private ProtoWorld _world;
        private readonly PlayerInputService _service;
        private readonly PlayerMovingConfig _config;

        public TranslatePlayerInputWalkToWalkRequestSystem(PlayerInputService service, PlayerMovingConfig config)
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
            if (!_service.WalkTriggered) return;

            var prepared = new WalkRequest
            {
                Factor = _service.Walk * _config.WalkSpeed
            };
            
            foreach (var e in _sharedAspect.Players)
            {
                var packed = _world.PackEntityWithWorld(e);
                MovingUtils.CreateWalkRequest(_requestsAspect, packed, prepared).AddPlayerTagToRequest(_requestsAspect);
            }
        }
    }
}