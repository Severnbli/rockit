using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public sealed class StorageRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SaveTrackedDataRequest> SaveTrackedDataRequestPool;
        public readonly ProtoIt SaveTrackedDataRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SaveTrackedDataRequest>());
    }
}