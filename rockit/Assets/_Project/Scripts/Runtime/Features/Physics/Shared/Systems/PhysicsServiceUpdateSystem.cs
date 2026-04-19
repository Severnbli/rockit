using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Systems
{
    public sealed class PhysicsServiceUpdateSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _physicsSharedAspect;
        private readonly PhysicsService _service;
        private readonly HashSetPool<Collider2D> _collider2DSetPool;
        private readonly HashSetPool<Rigidbody2D> _rigidbody2DSetPool;

        public PhysicsServiceUpdateSystem(PhysicsService service, IObjectDomain objectDomain)
        {
            _service = service;
            objectDomain.Get(out _collider2DSetPool);
            objectDomain.Get(out _rigidbody2DSetPool);
        }
        
        public void Init(IProtoSystems systems)
        {
            
        }

        public void Run()
        {
            var collider2DSet = _collider2DSetPool.Spawn();
            var rigidbody2DSet = _rigidbody2DSetPool.Spawn();

            foreach (var e in _physicsSharedAspect.Rigidbody2DColliders2D)
            {
                var collider = _physicsSharedAspect.Collider2DComponentPool.Get(e).Collider;
                var rigidbody = _physicsSharedAspect.Rigidbody2DComponentPool.Get(e).Rigidbody2D;
                collider2DSet.Add(collider);
                rigidbody2DSet.Add(rigidbody);
                
                _service.PhysicsMatcher.TryAdd(collider, rigidbody);
                _service.PhysicsMatcher.TrySet(collider, e);
                
                _service.GameObjectRigidbody2DMatcher.TryAdd(rigidbody.gameObject, rigidbody);
                _service.GameObjectRigidbody2DMatcher.TrySet(rigidbody, e);
            }
            
            _service.PhysicsMatcher.KeepOnly(collider2DSet);
            _service.GameObjectRigidbody2DMatcher.KeepOnly(rigidbody2DSet);
            
            _collider2DSetPool.Despawn(collider2DSet);
            _rigidbody2DSetPool.Despawn(rigidbody2DSet);
        }
    }
}