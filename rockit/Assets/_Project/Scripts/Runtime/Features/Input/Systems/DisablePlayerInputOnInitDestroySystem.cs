using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class DisablePlayerInputOnInitDestroySystem : IProtoInitSystem, IProtoDestroySystem
    {
        private readonly PlayerInputService _service;
        private readonly PlayerInputConfig _config;

        public DisablePlayerInputOnInitDestroySystem(PlayerInputService service, PlayerInputConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Init(IProtoSystems systems)
        {
            PlayerInputUtils.DisableInput(_service, _config);
        }

        public void Destroy()
        {
            PlayerInputUtils.DisableInput(_service, _config);
        }
    }
}