using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants
{
    public sealed class ConstantsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<RebuildConstantDisplayWindowRequest> RebuildConstantDisplayWindowRequestPool;
        public readonly ProtoPool<ShowConstantDisplayWindowRequest> ShowConstantDisplayWindowRequestPool;
        public readonly ProtoPool<HideConstantDisplayWindowRequest> HideConstantDisplayWindowRequestPool;
        public readonly ProtoIt RebuildConstantDisplayWindowRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, RebuildConstantDisplayWindowRequest>());
        public readonly ProtoIt ShowConstantDisplayWindowRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ShowConstantDisplayWindowRequest>());
        public readonly ProtoIt HideConstantDisplayWindowRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, HideConstantDisplayWindowRequest>());
    }
}