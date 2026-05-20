using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions.Shared
{
    public static class LayersExtensions
    {
        public static bool Identical(this LayerMask lMask, int layer)
        {
            return (lMask.value & (1 << layer)) != 0;
        }
    }
}