using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.World
{
    public static class TeleportersUtils
    {
        public static ProtoEntity CreateTeleporterTriggeredRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(
                aspect.WorldSharedRequestsAspect.TeleportersRequestsAspect.TeleporterTriggeredRequestPool, packed);
        }
    }
}