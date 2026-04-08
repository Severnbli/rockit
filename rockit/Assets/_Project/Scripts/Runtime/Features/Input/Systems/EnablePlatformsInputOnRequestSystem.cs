using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlatformsInputOnRequestSystem : IProtoRunSystem
    {
        [DI] private readonly InputAspect _inputAspect;
        private readonly PlatformsInputService _service;

        public EnablePlatformsInputOnRequestSystem(PlatformsInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}