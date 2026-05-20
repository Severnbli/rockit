using Unity.Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos
{
    public class PlayerCamera : MonoCamera
    {
        [SerializeField] private CinemachineConfiner2D _confiner;
        
        public CinemachineConfiner2D Confiner => _confiner;
    }
}