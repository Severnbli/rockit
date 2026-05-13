using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlatformsInputOnInitSystem : IProtoInitSystem
    {
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public EnablePlatformsInputOnInitSystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }
        
        public void Init(IProtoSystems systems)
        {
            PlatformsInputUtils.EnableInput(_service, _config);
        }
    }
}