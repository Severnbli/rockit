using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Player.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features
{
    public static class PlayerUtils
    {
        public static ProtoEntity CreatePlacePlayerRequest(RequestsAspect aspect, PlacePlayerRequest prepared)
        {
            return aspect.CreateRequest(aspect.PlayerRequestsAspect.PlacePlayerRequestPool, prepared: prepared);
        }

        public static ProtoEntity CreatePlayerTriggeredVoidRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlayerRequestsAspect.PlayerTriggeredVoidRequestPool);
        }

        public static ProtoEntity CreatePlacePlayerToLastCheckpointRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlayerRequestsAspect.PlacePlayerToLastCheckpointRequestPool);
        }

        public static ProtoEntity CreatePlayerEnterTriggerRequest(RequestsAspect aspect,
            PlayerEnterTriggerRequest prepared)
        {
            return aspect.CreateRequest(aspect.PlayerRequestsAspect.PlayerEnterTriggerRequestPool, prepared: prepared);
        }
    }
}