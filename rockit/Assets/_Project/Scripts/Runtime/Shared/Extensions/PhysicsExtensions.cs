using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PhysicsExtensions
    {
        public static bool TryCompareRigidbody2DRequest(this PhysicsSharedAspect physicsSharedAspect,
            CoreRequestsAspect coreRequestsAspect, ProtoEntity entity, ProtoWorld world, out ProtoEntity targetEntity)
        {
            return coreRequestsAspect.TryCompareRequestWorld(entity, world, out targetEntity) 
                   && physicsSharedAspect.Rigidbody2DComponentPool.Has(entity);
        }
    }
}