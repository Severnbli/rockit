using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class Rigidbody2DExtensions
    {
        public static void ApplyWalk(this Rigidbody2D rigidbody2D, float factor)
        {
            var velocity = rigidbody2D.linearVelocity;
            velocity.x = factor;
            rigidbody2D.linearVelocity = velocity;
        }
        
        public static void ApplyJump(this Rigidbody2D rigidbody2D, float factor)
        {
            var velocity = rigidbody2D.linearVelocity;
            velocity.y = 0f;
            rigidbody2D.linearVelocity = velocity;
            rigidbody2D.AddForce(Vector2.up * factor, ForceMode2D.Impulse);
        }

        public static void ApplyDash(this Rigidbody2D rigidbody2D, float factor, int direction)
        {
            factor = Mathf.Abs(factor);
            direction = Mathf.Clamp(direction, -1, 1);
            rigidbody2D.linearVelocity = new Vector2(factor * direction, 0f);
        }

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

        public static void ResetVelocityY(this Rigidbody2D rigidbody2D)
        {
            var velocity = rigidbody2D.linearVelocity;
            velocity.y = 0f;
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
    }
}