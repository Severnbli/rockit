using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyWalkDecelerationOnFixedRunSystem : IProtoFixedRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        
        public void FixedRun()
        {
            
        }
    }
}