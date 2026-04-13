using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class MovingUtils
    {
        public static ProtoEntity CreateWalkRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest();
            aspect.MovingRequestsAspect.WalkRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest();
            aspect.MovingRequestsAspect.JumpRequestPool.Add(entity);
            return entity;
        }
        
        public static ProtoEntity CreateDashRequest(RequestsAspect aspect)
        {
            var entity = aspect.CreateRequest();
            aspect.MovingRequestsAspect.DashRequestPool.Add(entity);
            return entity;
        }
    }
}