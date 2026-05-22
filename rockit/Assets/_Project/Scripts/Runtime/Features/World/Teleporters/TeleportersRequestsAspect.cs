using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.World.Teleporters.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Teleporters
{
    public sealed class TeleportersRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<TeleporterTriggeredRequest> TeleporterTriggeredRequestPool;
        public readonly ProtoIt TeleporterTriggeredRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, TeleporterTriggeredRequest>());
    }
}