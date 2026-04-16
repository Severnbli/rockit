using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class DashAirQuantityResetSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        
        public void Run()
        {
            foreach (var e in _mAspect.DashGroundCheckResults)
            {
                ref var gcResult = ref _mAspect.GroundCheckResultComponentPool.Get(e);

                if (!gcResult.Grounded) continue;
                
                ref var dComponent = ref _mAspect.DashComponentPool.Get(e);
                dComponent.AirQuantity = 0;
            }
        }
    }
}