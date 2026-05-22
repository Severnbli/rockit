using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared
{
    public sealed class PlatformsSharedRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PositionPlatformTriggeredRequest> PositionPlatformTriggeredRequestPool;
        public readonly ProtoIt PositionPlatformTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PositionPlatformTriggeredRequest>());

        public readonly ProtoPool<RotationPlatformTriggeredRequest> RotationPlatformTriggeredRequestPool;
        public readonly ProtoIt RotationPlatformTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, RotationPlatformTriggeredRequest>());
        
        public readonly ProtoPool<ScalePlatformTriggeredRequest> ScalePlatformTriggeredRequestPool;
        public readonly ProtoIt ScalePlatformTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ScalePlatformTriggeredRequest>());
        
        public readonly ProtoPool<AnyPlatformTriggeredRequest> AnyPlatformTriggeredRequestPool;
        public readonly ProtoIt AnyPlatformTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, AnyPlatformTriggeredRequest>());
        
        public readonly ProtoPool<PlatformsAreaServiceEnabledRequest> PlatformsAreaServiceEnabledRequestPool;
        public readonly ProtoIt PlatformsAreaServiceEnabledRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlatformsAreaServiceEnabledRequest>());
        
        public readonly ProtoPool<PlatformsAreaServiceDisabledRequest> PlatformsAreaServiceDisabledRequestPool;
        public readonly ProtoIt PlatformsAreaServiceDisabledRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlatformsAreaServiceDisabledRequest>());
        
        public readonly ProtoPool<ActivatePlatformRequest> ActivatePlatformRequestPool;
        public readonly ProtoIt ActivatePlatformRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ActivatePlatformRequest>());
        
        public readonly ProtoPool<PlatformDeactivatedRequest> PlatformDeactivatedRequestPool;
        public readonly ProtoIt PlatformDeactivatedRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PlatformDeactivatedRequest>());
    }
}