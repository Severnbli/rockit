using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Components
{
    public struct MoveSnapComponent
    {
        public Rigidbody2D Host;
        public Vector2 LastHostPos;
        public Rigidbody2D Tied;
    }
}