using _Project.Scripts.Runtime.Shared.Tools;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Services
{
    public sealed class PhysicsService
    {
        public BiValueDictionary<Collider2D, Rigidbody2D, ProtoEntity> PhysicsMatcher = new ();
    }
}