using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class DisablePlatformsInputOnDestroySystem : IProtoDestroySystem
    {
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public DisablePlatformsInputOnDestroySystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Destroy()
        {
            PlatformsInputUtils.DisableInput(_service, _config);
        }
    }
}