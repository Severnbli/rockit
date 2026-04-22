using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class TransformExtensions
    {
        public static void ScaleTo(this Transform transform, Vector3 scale, float speed, float deltaTime)
        {
            var newScale = Vector2.MoveTowards(
                transform.localScale,
                scale,
                speed * deltaTime
            );
            
            transform.localScale = newScale;
        }
    }
}