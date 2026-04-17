using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving
{
    public class MovingRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<WalkRequest> WalkRequestPool;
        public readonly ProtoPool<JumpRequest> JumpRequestPool;
        public readonly ProtoPool<DashRequest> DashRequestPool;
        public readonly ProtoPool<DashTimeoutRequest> DashTimeoutRequestPool;
        public readonly ProtoIt WalkRequests = new (It.Inc<RequestComponent, ActiveRequestTag, WalkRequest>());
        public readonly ProtoIt JumpRequests = new (It.Inc<RequestComponent, ActiveRequestTag, JumpRequest>());
        public readonly ProtoIt DashRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DashRequest>());
    }
}