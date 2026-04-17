using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
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
    }
}