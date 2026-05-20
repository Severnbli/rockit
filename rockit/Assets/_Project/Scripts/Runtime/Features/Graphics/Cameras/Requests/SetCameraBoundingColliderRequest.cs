using Unity.Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Requests
{
    public struct SetCameraBoundingColliderRequest
    {
        public CinemachineConfiner2D Confiner;
        public Collider2D Collider;
    }
}