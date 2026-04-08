using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class EnablePlayerInputOnRequestSystem : IProtoRunSystem
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

            _service.Enabled = true;
            _config.Walk.Enable();
            _config.Jump.Enable();
            _config.Dash.Enable();
        }
    }
}