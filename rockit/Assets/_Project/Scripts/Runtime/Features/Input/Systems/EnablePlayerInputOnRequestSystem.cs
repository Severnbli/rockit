using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlayerInputOnRequestSystem : IProtoRunSystem
    {
        [DI] private readonly InputAspect _inputAspect;
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