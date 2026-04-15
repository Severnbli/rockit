using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class MovingUtils
    {
        public static ProtoEntity CreateWalkRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, WalkRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.WalkRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, JumpRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.JumpRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateDashRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, DashRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.DashRequestPool, targetEntity, true,
                prepared);
            return entity;
        }
    }
}