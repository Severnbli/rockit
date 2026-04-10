using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class EnablePlatformsInputOnRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly InputRequestsAspect _inputAspect;
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public EnablePlatformsInputOnRequestSystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            if (_service.Enabled || _inputAspect.EnablePlatformsInputRequests.IsEmptySlow()) return;
            
            PlatformsInputUtils.EnableInput(_service, _config);
        }
    }
}