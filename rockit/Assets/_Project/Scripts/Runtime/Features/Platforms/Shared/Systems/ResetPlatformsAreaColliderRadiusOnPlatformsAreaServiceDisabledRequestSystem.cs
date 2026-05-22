using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class ResetPlatformsAreaColliderRadiusOnPlatformsAreaServiceDisabledRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        [DI] private readonly PlatformsSharedAspect _plsAspect;
        [DI] private readonly PhysicsSharedAspect _phsAspect;
        
        public void Run()
        {
            if (_psrAspect.PlatformsAreaServiceDisabledRequests.IsEmptySlow()) return;

            foreach (var e in _plsAspect.PlatformsAreaColliders)
            {
                ref var cComponent = ref _phsAspect.Collider2DComponentPool.Get(e);
                if (cComponent.Collider is not CircleCollider2D collider) continue;
                collider.radius = PlatformsSharedContracts.DefaultPlatformsAreaRadius;
            }
        }
    }
}