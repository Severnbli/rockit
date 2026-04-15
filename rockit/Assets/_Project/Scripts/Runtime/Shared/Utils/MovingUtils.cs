using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class MovingUtils
    {
        public static ProtoEntity CreateWalkRequest(RequestsAspect aspect, WalkRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.WalkRequestPool, fixedRun: true,
                prepared: prepared);
            return entity;
        }
        
        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect, JumpRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.JumpRequestPool, fixedRun: true,
                prepared: prepared);
            return entity;
        }
        
        public static ProtoEntity CreateDashRequest(RequestsAspect aspect, DashRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.DashRequestPool, fixedRun: true,
                prepared: prepared);
            return entity;
        }
    }
}