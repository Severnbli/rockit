using _Project.Scripts.Runtime.Features.Economy.Coins.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins
{
    public sealed class CoinsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CoinComponent> CoinComponentPool;
        public readonly ProtoPool<CoinsAmountComponent> CoinsAmountComponentPool;
        public readonly ProtoPool<CoinsTextUIOutputComponent> CoinsTextUIOutputComponentPool;
        public readonly ProtoIt Coins = new (It.Inc<CoinComponent>());
        public readonly ProtoIt CoinsAmountTextUIOutputs = new (It.Inc<CoinsAmountComponent, CoinsTextUIOutputComponent>());
        public readonly ProtoIt CoinsAmountButtons = new (It.Inc<CoinsAmountComponent, ButtonComponent>());
    }
}