using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Stats
{
    public static class ConstantsUtils
    {
        public static ProtoEntity CreateRebuildConstantDisplayWindowRequest(RequestsAspect aspect,
            RebuildConstantDisplayWindowRequest prepared)
        {
            return aspect.CreateRequest(
                aspect.StatsSharedRequestsAspect.ConstantsRequestsAspect.RebuildConstantDisplayWindowRequestPool,
                prepared: prepared);
        }

        public static ProtoEntity CreateShowConstantDisplayWindowRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.StatsSharedRequestsAspect.ConstantsRequestsAspect
                .ShowConstantDisplayWindowRequestPool);
        }

        public static ProtoEntity CreateHideConstantDisplayWindowRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.StatsSharedRequestsAspect.ConstantsRequestsAspect
                .HideConstantDisplayWindowRequestPool);
        }
    }
}