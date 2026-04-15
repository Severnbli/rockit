using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class TranslatePlayerInputDashToDashRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _aspect;
        private readonly PlayerInputService _service;

        public TranslatePlayerInputDashToDashRequestSystem(PlayerInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            if (!_service.DashTriggered) return;
            
            MovingUtils.CreateDashRequest(_aspect).AddPlayerTagToRequest(_aspect);
        }
    }
}