using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class Vector2Utils
    {
        public static bool DistanceLessThanValue(Vector2 a, Vector2 b, float value)
        {
            return (a - b).sqrMagnitude < value * value;
        }
    }
}