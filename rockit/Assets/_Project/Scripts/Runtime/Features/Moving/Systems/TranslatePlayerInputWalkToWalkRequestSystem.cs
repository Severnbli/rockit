using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Moving.Configs;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class TranslatePlayerInputWalkToWalkRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _aspect;
        private readonly PlayerInputService _service;
        private readonly PlayerMovingConfig _config;

        public TranslatePlayerInputWalkToWalkRequestSystem(PlayerInputService service, PlayerMovingConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (!_service.WalkTriggered) return;

            var prepared = new WalkRequest
            {
                Factor = _service.Walk
            };
            MovingUtils.CreateWalkRequest(_aspect, prepared).AddPlayerTagToRequest(_aspect);
        }
    }
}