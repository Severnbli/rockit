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

        public PhysicsServiceUpdateSystem(PhysicsService service, IObjectDomain objectDomain)
        {
            _service = service;
            objectDomain.Get(out _collider2DSetPool);
        }

        public void Run()
        {
            var collider2DSet = _collider2DSetPool.Spawn();

            foreach (var e in _physicsSharedAspect.Rigidbody2DColliders2D)
            {
                var collider = _physicsSharedAspect.Collider2DComponentPool.Get(e).Collider;
                var rigidbody = _physicsSharedAspect.Rigidbody2DComponentPool.Get(e).Rigidbody2D;
                collider2DSet.Add(collider);
                _service.PhysicsMatcher.TryAdd(collider, rigidbody);
                _service.PhysicsMatcher.TrySet(collider, e);
            }
            
            _service.PhysicsMatcher.KeepOnly(collider2DSet);
            
            _collider2DSetPool.Despawn(collider2DSet);
        }
    }
}