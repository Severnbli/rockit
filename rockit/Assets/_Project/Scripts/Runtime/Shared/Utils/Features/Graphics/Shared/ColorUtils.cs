using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Shared
{
    public static class ColorUtils
    {
        public static Color MoveTowards(Color a, Color b, float distance)
        {
            return Vector4.MoveTowards(a, b, distance);
        }

        public static bool Equals(Color a, Color b, float tolerance)
        {
            return Vector4.Distance(a, b) <= tolerance;
        }
    }
}