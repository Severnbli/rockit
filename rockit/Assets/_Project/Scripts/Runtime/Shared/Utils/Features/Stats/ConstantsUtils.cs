using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

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

        public static ProtoEntity CreateConstantCollectedRequests(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed, ConstantCollectedRequest prepared)
        {
            return aspect.CreateRequest(
                aspect.StatsSharedRequestsAspect.ConstantsRequestsAspect.ConstantCollectedRequestPool, packed,
                prepared: prepared);
        }

        public static ProtoEntity CreateConstantTriggeredRequests(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed, ConstantTriggeredRequest prepared)
        {
            return aspect.CreateRequest(
                aspect.StatsSharedRequestsAspect.ConstantsRequestsAspect.ConstantTriggeredRequestPool, packed,
                prepared: prepared);
        }

        public static bool GetInvestigatedStatus(DataProvider dProvider, int constantId)
        {
            return dProvider.StatsData.InvestigatedConstants.ContainsKey(constantId);
        }
    }
}