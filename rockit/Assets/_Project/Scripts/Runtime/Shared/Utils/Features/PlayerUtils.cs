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
    }
}