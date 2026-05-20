using Unity.Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics
{
    public static class CamerasExtensions
    {
        public static void SetBoundingShape(this CinemachineConfiner2D confiner, Collider2D collider)
        {
            confiner.BoundingShape2D = collider;
            confiner.InvalidateBoundingShapeCache();
        }
    }
}