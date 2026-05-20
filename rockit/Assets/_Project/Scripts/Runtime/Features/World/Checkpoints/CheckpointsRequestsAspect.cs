using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.World.Checkpoints.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Checkpoints
{
    public sealed class CheckpointsRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ActivateCheckpointRequest> ActivateCheckpointRequestPool;
        public readonly ProtoIt ActivateCheckpointRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, ActivateCheckpointRequest>());
    }
}