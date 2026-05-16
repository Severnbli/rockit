using Unity.Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos
{
    public class MonoCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _camera;
        
        public CinemachineCamera Camera => _camera;
    }
}