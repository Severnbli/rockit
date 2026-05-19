using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features
{
    public static class PlatformsUtils
    {
        public static ProtoEntity CreatePositionPlatformTriggeredRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.PositionPlatformsTriggeredRequestPool);
        }

        public static ProtoEntity CreateRotationPlatformTriggeredRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.RotationPlatformsTriggeredRequestPool);
        }

        public static ProtoEntity CreateScalePlatformTriggeredRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlatformsSharedRequestsAspect.ScalePlatformsTriggeredRequestPool);
        }
    }
}