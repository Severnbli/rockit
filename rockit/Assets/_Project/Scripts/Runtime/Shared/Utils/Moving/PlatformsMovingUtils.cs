using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Moving
{
    public static class PlatformsMovingUtils
    {
        public static ProtoEntity CreateUpdatePlatformPositionRequest(RequestsAspect aspect, 
            ProtoPackedEntityWithWorld packed = default)
        {
            return aspect.CreateRequest(aspect.PlatformsMovingRequestsAspect.UpdatePlatformPositionRequestPool, packed);
        }
        
        public static ProtoEntity CreateUpdatePlatformRotationRequest(RequestsAspect aspect, 
            ProtoPackedEntityWithWorld packed = default)
        {
            return aspect.CreateRequest(aspect.PlatformsMovingRequestsAspect.UpdatePlatformRotationRequestPool, packed);
        }
        
        public static ProtoEntity CreateUpdatePlatformScaleRequest(RequestsAspect aspect, 
            ProtoPackedEntityWithWorld packed = default)
        {
            return aspect.CreateRequest(aspect.PlatformsMovingRequestsAspect.UpdatePlatformScaleRequestPool, packed);
        }
    }
}