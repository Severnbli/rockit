using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class DashAirQuantityResetOnGroundedSystem : IProtoRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        
        public void Run()
        {
            foreach (var e in _cmAspect.DashGroundCheckResults)
            {
                ref var gcResult = ref _cmAspect.GroundCheckResultComponentPool.Get(e);

                if (!gcResult.Grounded) continue;
                
                ref var dComponent = ref _cmAspect.DashComponentPool.Get(e);
                dComponent.AirQuantity = 0;
            }
        }
    }
}