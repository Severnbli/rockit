using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class PlatformsInputServiceUpdateSystem : IProtoRunSystem
    {
        private readonly PlatformsInputService _service;

        public PlatformsInputServiceUpdateSystem(PlatformsInputService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}