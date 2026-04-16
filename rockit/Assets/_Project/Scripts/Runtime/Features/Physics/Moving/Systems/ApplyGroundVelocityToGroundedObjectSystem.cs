using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyGroundVelocityToGroundedObjectSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        private readonly PhysicsService _service;

        public ApplyGroundVelocityToGroundedObjectSystem(PhysicsService service)
        {
            _service = service;
        }

        public void FixedRun()
        {
            foreach (var e in _movingAspect.Rigidbody2DGroundCheckResults)
            {
                ref var result = ref _movingAspect.GroundCheckResultComponentPool.Get(e);

                if (!result.Grounded ||
                    !_service.PhysicsMatcher.TryGetByFirst(result.GroundCollider, out var groundRigidbody)) continue;
                
                ref var rigidbody = ref _physicsSharedAspect.Rigidbody2DComponentPool.Get(e);
                
                rigidbody.Rigidbody2D.linearVelocity += groundRigidbody.linearVelocity;
            }
        }
    }
}