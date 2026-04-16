using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyGroundVelocityToGroundedObjectSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        
        public void FixedRun()
        {
            foreach (var e in _movingAspect.Rigidbody2DGroundCheckResults)
            {
                var result = _movingAspect.GroundCheckResultComponentPool.Get(e);

                if (!result.Grounded) continue;
                    
                var rigidbody = _sharedAspect.Rigidbody2DComponentPool.Get(e);
            }
        }
    }
}