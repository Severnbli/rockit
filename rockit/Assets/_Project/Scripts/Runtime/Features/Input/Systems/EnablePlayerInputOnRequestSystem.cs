using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class EnablePlayerInputOnRequestSystem : IProtoRunSystem
    {
        [DI] private readonly InputAspect _inputAspect;
        private readonly PlayerInputService _service;

        public EnablePlayerInputOnRequestSystem(PlayerInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}