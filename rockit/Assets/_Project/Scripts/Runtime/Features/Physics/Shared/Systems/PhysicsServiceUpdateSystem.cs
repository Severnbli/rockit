using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class PhysicsServiceUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        private readonly PhysicsService _service;

        public PhysicsServiceUpdateSystem(PhysicsService service)
        {
            _service = service;
        }

        public void Run()
        {
            
        }
    }
}