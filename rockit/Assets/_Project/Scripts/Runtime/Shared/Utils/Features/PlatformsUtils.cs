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
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.RotationPlatformsTriggeredRequestPool,
                packed);
        }

        public static ProtoEntity CreateScalePlatformTriggeredRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)

        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.ScalePlatformsTriggeredRequestPool, packed);
        }
    }
}