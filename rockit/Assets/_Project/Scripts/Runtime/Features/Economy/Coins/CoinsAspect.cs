using _Project.Scripts.Runtime.Features.Economy.Coins.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins
{
    public sealed class CoinsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<CoinComponent> CoinComponentPool;
    }
}