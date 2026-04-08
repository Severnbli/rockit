using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlatformsInputOnRequestSystem : IProtoRunSystem
    {
        [DI] private readonly InputAspect _inputAspect;
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public EnablePlatformsInputOnRequestSystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            
        }
    }
}