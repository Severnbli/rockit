using _Project.Scripts.Runtime.Shared.Tools;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Services
{
    public sealed class PhysicsService
    {
        public readonly BiValueDictionary<Collider2D, Rigidbody2D, ProtoEntity> PhysicsMatcher = new ();
        public readonly BiValueDictionary<GameObject, Rigidbody2D, ProtoEntity> GameObjectRigidbody2DMatcher = new ();
    }
}