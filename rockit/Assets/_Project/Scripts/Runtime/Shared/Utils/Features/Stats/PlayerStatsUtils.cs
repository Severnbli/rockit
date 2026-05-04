using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Stats
{
    public static class PlayerStatsUtils
    {
        public static ProtoEntity CreateUpdatePlayerStatsServiceRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.PlayerStatsRequestsAspect.UpdatePlayerStatsServiceRequestPool);
        }
    }
}