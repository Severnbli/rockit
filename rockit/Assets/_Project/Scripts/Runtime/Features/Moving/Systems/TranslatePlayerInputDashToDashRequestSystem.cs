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
    public sealed class TranslatePlayerInputDashToDashRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _requestsAspect;
        [DI] private readonly SharedAspect _sharedAspect;
        private readonly PlayerInputService _service;
        private readonly PlayerMovingConfig _config;

        public TranslatePlayerInputDashToDashRequestSystem(PlayerInputService service, PlayerMovingConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Init(IProtoSystems systems)
        {
            
        }

        public void Run()
        {
            if (!_service.DashTriggered) return;

            var prepared = new DashRequest
            {
                Factor = _config.DashPower
            };
            
            var world = _sharedAspect.World();
            foreach (var e in _sharedAspect.Players)
            {
                var packed = world.PackEntityWithWorld(e); 
                MovingUtils.CreateDashRequest(_requestsAspect, packed, prepared).AddPlayerTagToRequest(_requestsAspect);
            }
        }
    }
}