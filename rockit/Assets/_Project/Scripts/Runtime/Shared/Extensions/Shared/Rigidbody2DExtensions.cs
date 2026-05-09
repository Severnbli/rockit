using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
{
    public static class Rigidbody2DExtensions
    {
        public static bool Falling(this Rigidbody2D rigidbody2D)
        {
            return rigidbody2D.linearVelocity.y < 0f;
        }

        public static void MoveTo(this Rigidbody2D rigidbody2D, Vector2 pos, float speed, float deltaTime)
        {
            var newPosition = Vector2.MoveTowards(
                rigidbody2D.position,
                pos,
                speed * deltaTime
            );
            
            rigidbody2D.MovePosition(newPosition);
        }
        
        public static void RotateTo(this Rigidbody2D rigidbody2D, Quaternion angle, float speed, float deltaTime)
        {
            var newAngle = Mathf.MoveTowardsAngle(
                rigidbody2D.rotation,
                angle.eulerAngles.z,
                speed * deltaTime
            );
            
            rigidbody2D.MoveRotation(newAngle);
        }
    }
}