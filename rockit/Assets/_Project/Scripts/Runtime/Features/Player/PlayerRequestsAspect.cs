using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Player.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player
{
    public sealed class PlayerRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlacePlayerRequest> PlacePlayerRequestPool;
        public readonly ProtoIt PlacePlayerRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlacePlayerRequest>());
    }
}