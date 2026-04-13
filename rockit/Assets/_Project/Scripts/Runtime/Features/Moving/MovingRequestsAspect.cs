using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving
{
    public class MovingRequestsAspect : ProtoAspectInject
    {
        public ProtoPool<WalkRequest> WalkRequestPool;
        public ProtoPool<JumpRequest> JumpRequestPool;
        public ProtoPool<DashRequest> DashRequestPool;
        public ProtoIt PlayerWalkRequests = new (It.Inc<RequestComponent, ActiveRequestTag, WalkRequest, PlayerTag>());
        public ProtoIt PlayerJumpRequests = new (It.Inc<RequestComponent, ActiveRequestTag, JumpRequest, PlayerTag>());
        public ProtoIt PlayerDashRequests = new (It.Inc<RequestComponent, ActiveRequestTag, DashRequest, PlayerTag>());
    }
}