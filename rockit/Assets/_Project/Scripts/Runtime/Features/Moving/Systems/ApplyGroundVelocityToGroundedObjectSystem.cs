using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class ApplyGroundVelocityToGroundedObjectSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        
        public void FixedRun()
        {
            
        }
    }
}