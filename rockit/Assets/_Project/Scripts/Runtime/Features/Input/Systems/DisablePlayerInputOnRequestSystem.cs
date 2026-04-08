using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class DisablePlayerInputOnRequestSystem : IProtoRunSystem
    {
        [DI] private readonly InputAspect _inputAspect;
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public DisablePlayerInputOnRequestSystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            
        }
    }
}