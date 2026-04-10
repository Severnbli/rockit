using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class RequestsExtensions
    {
        public static ProtoEntity CreateRequest(this RequestsAspect aspect, ProtoPackedEntityWithWorld targetEntity = default,
            bool fixedRun = false)
        {
            ref var request = ref aspect.CoreRequestsAspect.RequestComponentPool.NewEntity(out var entity);
            request.Entity = targetEntity;

            if (!fixedRun)
            {
                aspect.CoreRequestsAspect.RunRequestTagPool.Add(entity);
            }
            else
            {
                aspect.CoreRequestsAspect.FixedRunRequestTagPool.Add(entity);
            }
            
            return entity;
        }
    }
}