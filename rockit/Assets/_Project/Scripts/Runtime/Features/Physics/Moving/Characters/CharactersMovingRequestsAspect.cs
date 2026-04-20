using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters
{
    public class CharactersMovingRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<WalkRequest> WalkRequestPool;
        public readonly ProtoPool<JumpRequest> JumpRequestPool;
        public readonly ProtoPool<DashRequest> DashRequestPool;
        public readonly ProtoPool<DashTimeoutRequest> DashTimeoutRequestPool;
        public readonly ProtoPool<JumpAppliedRequest> JumpAppliedRequestPool;
        public readonly ProtoIt WalkRequests = new (It.Inc<RequestComponent, ActiveRequestTag, WalkRequest>());
        public readonly ProtoIt JumpRequests = new (It.Inc<RequestComponent, ActiveRequestTag, JumpRequest>());
        public readonly ProtoIt DashRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DashRequest>());
        public readonly ProtoIt DashTimeoutRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DashTimeoutRequest>());
        public readonly ProtoIt JumpAppliedRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, JumpAppliedRequest>());
        public readonly ProtoIt JumpAppliedFixedRunRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, JumpAppliedRequest>());
    }
}