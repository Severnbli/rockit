using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Callback.Events
{
    public struct UnityPhysics2DCollisionStayEvent
    {
        public string SenderName;
        public GameObject Sender;
        public Collider2D Collider;
        public Vector2 Point;
        public Vector2 Normal;
        public Vector2 Velocity;
    }
}