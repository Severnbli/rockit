using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnableDisablePlatformsInputOnInitDestroySystem : IProtoInitSystem, IProtoDestroySystem
    {
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public EnableDisablePlatformsInputOnInitDestroySystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Init(IProtoSystems systems)
        {
            PlatformsInputUtils.EnableInput(_service, _config);
        }

        public void Destroy()
        {
            PlatformsInputUtils.DisableInput(_service, _config);
        }
    }
}