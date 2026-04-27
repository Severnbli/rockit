using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class StorageUtils
    {
        public static ProtoEntity CreateSaveTrackedDataRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.StorageRequestsAspect.SaveTrackedDataRequestPool);
        }

        public static ProtoEntity CreateLoadTrackedDataRequest(RequestsAspect aspect)
        {
            return aspect.CreateRequest(aspect.StorageRequestsAspect.LoadTrackedDataRequestPool);
        }
    }
}