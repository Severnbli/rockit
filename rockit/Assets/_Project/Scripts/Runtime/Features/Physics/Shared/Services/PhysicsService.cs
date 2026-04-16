using _Project.Scripts.Runtime.Shared.Tools;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Shared.Services
{
    public sealed class PhysicsService
    {
        public BiDictionary<Collider2D, Rigidbody2D> PhysicsMatcher = new ();
    }
}