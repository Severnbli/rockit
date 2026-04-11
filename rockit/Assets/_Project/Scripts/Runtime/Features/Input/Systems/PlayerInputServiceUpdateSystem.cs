using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlayerInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlayerInputService _service;

        public PlayerInputServiceUpdateSystem(PlayerInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}