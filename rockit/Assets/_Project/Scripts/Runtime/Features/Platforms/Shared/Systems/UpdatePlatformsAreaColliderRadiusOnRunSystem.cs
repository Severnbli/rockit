using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class UpdatePlatformsAreaColliderRadiusOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsSharedAspect _plsAspect;
        [DI] private readonly PhysicsSharedAspect _phsAspect;
        private readonly PlatformsAreaService _paService;

        public UpdatePlatformsAreaColliderRadiusOnRunSystem(PlatformsAreaService paService)
        {
            _paService = paService;
        }

        public void Run()
        {
            if (!_paService.Enabled) return; 
            
            foreach (var e in _plsAspect.PlatformsAreaColliders)
            {
                ref var cComponent = ref _phsAspect.Collider2DComponentPool.Get(e);
                if (cComponent.Collider is not CircleCollider2D collider) continue;
                collider.radius = _paService.Radius;
            }
        }
    }
}