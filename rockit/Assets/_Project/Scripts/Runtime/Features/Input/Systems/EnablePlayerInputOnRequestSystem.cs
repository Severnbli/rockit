using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlayerInputOnRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly InputRequestsAspect _inputAspect;
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public EnablePlayerInputOnRequestSystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (_service.Enabled || _inputAspect.EnablePlayerInputRequests.IsEmptySlow()) return;

            PlayerInputUtils.EnableInput(_service, _config);
        }
    }
}