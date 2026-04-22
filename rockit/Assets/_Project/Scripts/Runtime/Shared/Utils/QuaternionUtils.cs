using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class QuaternionUtils
    {
        public static bool AngleLessThanValue(Quaternion a, Quaternion b, float value)
        {
            return Quaternion.Angle(a, b) < value;
        }
    }
}