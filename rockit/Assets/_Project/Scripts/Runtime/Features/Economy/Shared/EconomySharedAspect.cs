using _Project.Scripts.Runtime.Features.Economy.Coins;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Shared
{
    public sealed class EconomySharedAspect : ProtoAspectInject
    {
        public readonly CoinsAspect CoinsAspect;
    }
}