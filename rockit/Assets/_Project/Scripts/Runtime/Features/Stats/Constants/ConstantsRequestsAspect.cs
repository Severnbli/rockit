using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants
{
    public sealed class ConstantsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<BuildConstantDisplayWindowRequest> BuildConstantDisplayWindowRequestPool;
        public readonly ProtoIt BuildConstantDisplayWindowRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, BuildConstantDisplayWindowRequest>());
    }
}