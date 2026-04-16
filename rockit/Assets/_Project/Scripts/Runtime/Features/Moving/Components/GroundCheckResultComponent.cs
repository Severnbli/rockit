using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Components
{
    public struct GroundCheckResultComponent
    {
        public bool Grounded;
        public Collider2D GroundCollider;
        public float LastGroundedTiming;
    }
}