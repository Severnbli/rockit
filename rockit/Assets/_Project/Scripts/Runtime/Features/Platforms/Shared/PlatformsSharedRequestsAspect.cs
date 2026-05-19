using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared
{
    public sealed class PlatformsSharedRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PositionPlatformsTriggeredRequest> PositionPlatformsTriggeredRequestPool;
        public readonly ProtoIt PositionPlatformsTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, PositionPlatformsTriggeredRequest>());

        public readonly ProtoPool<RotationPlatformsTriggeredRequest> RotationPlatformsTriggeredRequestPool;
        public readonly ProtoIt RotationPlatformsTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, RotationPlatformsTriggeredRequest>());
    }
}