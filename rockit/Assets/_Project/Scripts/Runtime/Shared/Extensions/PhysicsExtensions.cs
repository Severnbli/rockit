using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PhysicsExtensions
    {
        public static bool TryCompareRigidbody2DRequest(this PhysicsSharedAspect physicsSharedAspect,
            CoreRequestsAspect coreRequestsAspect, ProtoEntity entity, ProtoWorld world, out ProtoEntity targetEntity, 
            out Rigidbody2DComponent rigidbody2DComponent)
        {
            rigidbody2DComponent = default;
            
            var compared = coreRequestsAspect.TryCompareRequestWorld(entity, world, out targetEntity) 
                           && physicsSharedAspect.Rigidbody2DComponentPool.Has(targetEntity);
            
            if (compared)
            {
                rigidbody2DComponent = physicsSharedAspect.Rigidbody2DComponentPool.Get(targetEntity);
            }
            
            return compared;
        }
    }
}