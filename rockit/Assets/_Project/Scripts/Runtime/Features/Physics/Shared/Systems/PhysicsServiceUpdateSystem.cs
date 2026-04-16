using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class PhysicsServiceUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        private readonly PhysicsService _service;
        private readonly ObjectDomain _objectDomain;

        public PhysicsServiceUpdateSystem(PhysicsService service, ObjectDomain objectDomain)
        {
            _service = service;
            _objectDomain = objectDomain;
        }

        public void Run()
        {
            
        }
    }
}