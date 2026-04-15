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
            var entity = aspect.CreateRequest(fixedRun: true);
            ref var request = ref aspect.MovingRequestsAspect.WalkRequestPool.Add(entity);
            request = prepared;
            return entity;
        }
        
        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest(fixedRun: true);
            aspect.MovingRequestsAspect.JumpRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDashRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest(fixedRun: true);
            aspect.MovingRequestsAspect.DashRequestPool.Add(entity);
            return entity;
        }
    }
}