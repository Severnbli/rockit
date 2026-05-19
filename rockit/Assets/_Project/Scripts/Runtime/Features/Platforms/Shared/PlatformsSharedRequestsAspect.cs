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
        
        public readonly ProtoPool<ScalePlatformsTriggeredRequest> ScalePlatformsTriggeredRequestPool;
        public readonly ProtoIt ScalePlatformsTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ScalePlatformsTriggeredRequest>());
    }
}