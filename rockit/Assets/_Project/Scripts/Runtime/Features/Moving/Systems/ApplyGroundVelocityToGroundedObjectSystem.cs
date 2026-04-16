using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class ApplyGroundVelocityToGroundedObjectSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        [DI] private readonly SharedAspect _sharedAspect;
        
        public void FixedRun()
        {
            
        }
    }
}