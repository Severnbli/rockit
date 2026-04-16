using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PhysicsExtensions
    {
        public static bool TryCompareRigidbody2DRequest(this PhysicsSharedAspect physicsSharedAspect,
            CoreRequestsAspect coreRequestsAspect, ProtoEntity requestEntity, ProtoWorld world, 
            out ProtoEntity targetEntity, out Rigidbody2D rigidbody)
        {
            rigidbody = null;
            
            var compared = coreRequestsAspect.TryCompareRequestWorld(requestEntity, world, out targetEntity) 
                           && physicsSharedAspect.Rigidbody2DComponentPool.Has(targetEntity);
            
            if (compared)
            {
                ref var rigidbody2DComponent = ref physicsSharedAspect.Rigidbody2DComponentPool.Get(targetEntity);
                rigidbody = rigidbody2DComponent.Rigidbody2D;
            }
            
            return compared;
        }
    }
}