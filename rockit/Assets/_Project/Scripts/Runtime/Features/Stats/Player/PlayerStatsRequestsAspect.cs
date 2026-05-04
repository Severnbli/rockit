using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Stats.Player.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Player
{
    public sealed class PlayerStatsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UpdatePlayerStatsServiceRequest> UpdatePlayerStatsServiceRequestPool;
        public readonly ProtoIt UpdatePlayerStatsRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, UpdatePlayerStatsServiceRequest>());
    }
}