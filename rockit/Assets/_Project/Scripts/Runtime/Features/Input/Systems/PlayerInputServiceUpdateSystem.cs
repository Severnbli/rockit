using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlayerInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public PlayerInputServiceUpdateSystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            
        }
    }
}