using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlatformsInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlatformsInputService _service;
        private readonly PlatformsInputConfig _config;

        public PlatformsInputServiceUpdateSystem(PlatformsInputService service, PlatformsInputConfig config)
        {
            _service = service;
            _config = config;
        }

        public void Run()
        {
            
        }
    }
}