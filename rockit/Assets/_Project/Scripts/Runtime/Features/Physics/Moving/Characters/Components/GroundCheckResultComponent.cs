using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components
{
    public struct GroundCheckResultComponent
    {
        public bool Grounded;
        public Collider2D GroundCollider;
        public float LastGroundedTiming;
    }
}