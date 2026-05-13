using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Economy.Coins.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins
{
    public sealed class CoinsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<WasteCoinsRequest> WasteCoinsRequestPool;
        public readonly ProtoIt WasteCoinsRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, WasteCoinsRequest>());
    }
}