using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UpdatePlatformPositionRequest> UpdatePlatformPositionRequestPool;
        public readonly ProtoPool<UpdatePlatformRotationRequest> UpdatePlatformRotationRequestPool;
        public readonly ProtoPool<UpdatePlatformScaleRequest> UpdatePlatformScaleRequestPool;
        public readonly ProtoIt UpdatePlatformPositionRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, UpdatePlatformPositionRequest>());
        public readonly ProtoIt UpdatePlatformRotationRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, UpdatePlatformRotationRequest>());
        public readonly ProtoIt UpdatePlatformScaleRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, UpdatePlatformScaleRequest>());
    }
}