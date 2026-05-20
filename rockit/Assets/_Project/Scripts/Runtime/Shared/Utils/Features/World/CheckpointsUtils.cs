using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.World
{
    public static class CheckpointsUtils
    {
        public static ProtoEntity CreateActivateCheckpointRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld packed)
        {
            return aspect.CreateRequest(
                aspect.WorldSharedRequestsAspect.CheckpointsRequestsAspect.ActivateCheckpointRequestPool, packed);
        }
    }
}