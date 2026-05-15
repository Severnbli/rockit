using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class UpdateCoinsTextUIOutputWithCoinsAmountSystem : IProtoRunSystem
    {
        [DI] private readonly CoinsAspect _cAspect;
        
        public void Run()
        {
            foreach (var e in _cAspect.CoinsAmountTextUIOutputs)
            {
                ref var ctuoComponent = ref _cAspect.CoinsTextUIOutputComponentPool.Get(e);
                ref var caComponent = ref _cAspect.CoinsAmountComponentPool.Get(e);
                ctuoComponent.Text.text = caComponent.Amount.ToString();
            }
        }
    }
}