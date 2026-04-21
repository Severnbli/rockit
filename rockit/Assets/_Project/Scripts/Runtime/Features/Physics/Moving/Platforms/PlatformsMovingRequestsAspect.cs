using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<UpdatePlatformPositionRequest> UpdatePlatformPositionRequestPool;
        public readonly ProtoIt UpdatePlatformPositionRequests = new (It.Inc<UpdatePlatformPositionRequest>());
    }
}