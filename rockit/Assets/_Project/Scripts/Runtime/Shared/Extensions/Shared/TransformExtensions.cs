using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
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

        public static void PlaceTo(this Transform transform, Vector2 to)
        {
            transform.position = new Vector3(to.x, to.y, transform.position.z);
        }
    }
}