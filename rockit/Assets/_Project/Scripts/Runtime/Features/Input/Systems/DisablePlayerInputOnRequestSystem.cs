using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class DisablePlayerInputOnRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly InputAspect _inputAspect;
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public DisablePlayerInputOnRequestSystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (!_service.Enabled || _inputAspect.DisablePlayerInputRequests.IsEmptySlow()) return;
            
            PlayerInputUtils.DisableInput(_service, _config);
        }
    }
}