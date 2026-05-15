using _Project.Scripts.Runtime.Features.Economy.Coins.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins
{
    public sealed class CoinsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CoinComponent> CoinComponentPool;
        public readonly ProtoPool<CoinsAmountComponent> CoinsAmountComponentPool;
        public readonly ProtoPool<CoinsTextUIOutputComponent> CoinsAmountTextUIOutputComponentPool;
        public readonly ProtoIt Coins = new (It.Inc<CoinComponent>());
        public readonly ProtoIt CoinsAmountTextUIOutputs = new (It.Inc<CoinsAmountComponent, CoinsTextUIOutputComponent>());
    }
}