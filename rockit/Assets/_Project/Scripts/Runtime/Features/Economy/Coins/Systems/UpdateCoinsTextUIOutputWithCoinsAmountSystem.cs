using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class UpdateCoinsTextUIOutputWithCoinsAmountSystem : IProtoRunSystem
    {
        [DI] private readonly CoinsAspect _cAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        
        public void Run()
        {
            foreach (var e in _cAspect.CoinsAmountTextUis)
            {
                ref var ctuoComponent = ref _tsAspect.TextUiComponentPool.Get(e);
                ref var caComponent = ref _cAspect.CoinsAmountComponentPool.Get(e);
                ctuoComponent.Text.text = caComponent.Amount.ToString();
            }
        }
    }
}