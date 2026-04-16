using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class PhysicsServiceUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        private readonly PhysicsService _service;
        private readonly HashSetPool<Collider2D> _collider2DSetPool;

        public PhysicsServiceUpdateSystem(PhysicsService service, ObjectDomain objectDomain)
        {
            _service = service;
            objectDomain.Get(out _collider2DSetPool);
        }

        public void Run()
        {
            
        }
    }
}