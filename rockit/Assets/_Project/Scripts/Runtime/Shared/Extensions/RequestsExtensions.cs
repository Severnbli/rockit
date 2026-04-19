using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class RequestsExtensions
    {
        public static ProtoEntity CreateRequest(this RequestsAspect aspect, ProtoPackedEntityWithWorld targetEntity = default,
            bool fixedRun = false)
        {
            return CreateRequest(aspect.CoreRequestsAspect, targetEntity, fixedRun);
        }
        
        public static ProtoEntity CreateRequest(this CoreRequestsAspect aspect, ProtoPackedEntityWithWorld targetEntity = default,
            bool fixedRun = false)
        {
            ref var request = ref aspect.RequestComponentPool.NewEntity(out var entity);
            request.Entity = targetEntity;

            if (!fixedRun)
            {
                aspect.RunRequestTagPool.Add(entity);
            }
            else
            {
                aspect.FixedRunRequestTagPool.Add(entity);
            }
            
            return entity;
        }

        public static ProtoEntity CreateRequest<T>(this RequestsAspect aspect, ProtoPool<T> pool,
            ProtoPackedEntityWithWorld targetEntity = default, bool fixedRun = false, T prepared = default) 
            where T : struct
        {
            var entity = aspect.CreateRequest(targetEntity, fixedRun);
            ref var request = ref pool.Add(entity);
            request = prepared;
            return entity;
        }

        public static bool TryCompareRequestWorld(this CoreRequestsAspect aspect, ProtoEntity entity, ProtoWorld world, 
            out ProtoEntity targetEntity)
        {
            targetEntity = default;
            
            if (!aspect.RequestComponentPool.Has(entity)) return false;

            var request = aspect.RequestComponentPool.Get(entity);
            var packed = request.Entity;
            return packed.TryUnpack(out var packedWorld, out targetEntity) && packedWorld.Equals(world);
        }
        
        public static bool TryCompareRequestWorld(this RequestsAspect aspect, ProtoEntity entity, ProtoWorld world, 
            out ProtoEntity targetEntity)
        {
            return TryCompareRequestWorld(aspect.CoreRequestsAspect, entity, world, out targetEntity);
        }
    }
}