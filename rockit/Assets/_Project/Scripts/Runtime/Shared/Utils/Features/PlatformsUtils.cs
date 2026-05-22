using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Features
{
    public static class PlatformsUtils
    {
        public static ProtoEntity CreatePositionPlatformTriggeredRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PositionPlatformTriggeredRequestPool,
                packed);
        }

        public static ProtoEntity CreateRotationPlatformTriggeredRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.RotationPlatformTriggeredRequestPool,
                packed);
        }

        public static ProtoEntity CreateScalePlatformTriggeredRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.ScalePlatformTriggeredRequestPool, packed);
        }

        public static ProtoEntity CreateAnyPlatformTriggeredRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.AnyPlatformTriggeredRequestPool);
        }

        public static ProtoEntity CreatePlatformsAreaServiceEnabledRequests(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PlatformsAreaServiceEnabledRequestPool);
        }

        public static ProtoEntity CreatePlatformsAreaServiceDisabledRequests(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PlatformsAreaServiceDisabledRequestPool);
        }

        public static ProtoEntity CreateActivatePlatformRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PlatformActivatedRequestPool, packed);
        }

        public static ProtoEntity CreatePlatformDeactivatedRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PlatformDeactivatedRequestPool, packed);
        }
    }
}