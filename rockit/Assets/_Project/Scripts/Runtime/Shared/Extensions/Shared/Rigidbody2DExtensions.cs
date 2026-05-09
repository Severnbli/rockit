using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
{
    public static class Rigidbody2DExtensions
    {
        public static bool VelocityXZero(this Rigidbody2D rigidbody2D)
        {
            return Mathf.Approximately(rigidbody2D.linearVelocityX, 0f);
        }

        public static void ApplyWalkDeceleration(this Rigidbody2D rigidbody2D, float factor, float deltaTime)
        {
            var velocity = rigidbody2D.linearVelocity;

            velocity.x = Mathf.MoveTowards(
                velocity.x,
                0f,
                factor * deltaTime
            );
            
            rigidbody2D.linearVelocity = velocity;
        }

        public static void ApplyJumpDeceleration(this Rigidbody2D rigidbody2D, float factor, float deltaTime)
        {
            if (rigidbody2D.linearVelocity.y <= 0f) return;
            
            var velocity = rigidbody2D.linearVelocity;
            
            velocity.y = Mathf.MoveTowards(
                velocity.x,
                0f,
                factor * deltaTime
            );
            
            rigidbody2D.linearVelocity = velocity;
        }

        public static void ResetVelocityY(this Rigidbody2D rigidbody2D)
        {
            var velocity = rigidbody2D.linearVelocity;
            velocity.y = 0f;
            rigidbody2D.linearVelocity = velocity;
        }

        public static void ResetVelocityX(this Rigidbody2D rigidbody2D)
        {
            var velocity = rigidbody2D.linearVelocity;
            velocity.x = 0f;
            rigidbody2D.linearVelocity = velocity;
        }

        public static void ResetPositiveVelocityY(this Rigidbody2D rigidbody2D)
        {
            if (rigidbody2D.linearVelocity.y < 0f) return;
            rigidbody2D.ResetVelocityY();
        }

        public static void ResetPositiveVelocityYOnSideCollision(this Rigidbody2D rigidbody2D, Vector2 normal, float tolerance)
        {
            if (Mathf.Abs(normal.x) < tolerance) return;
            rigidbody2D.ResetPositiveVelocityY();
        }

        public static void ResetVelocityXOnSideCollision(this Rigidbody2D rigidbody2D, Vector2 normal, float tolerance)
        {
            if (Mathf.Abs(normal.x) < tolerance) return;
            rigidbody2D.ResetVelocityX();
        }

        public static bool Falling(this Rigidbody2D rigidbody2D)
        {
            return rigidbody2D.linearVelocity.y < 0f;
        }

        public static bool MoveSideways(this Rigidbody2D rigidbody2D)
        {
            return !Mathf.Approximately(rigidbody2D.linearVelocity.x, 0f);
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