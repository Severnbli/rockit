using Unity.Cinemachine;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos
{
    public class CameraBrain : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain _brain;
        
        public CinemachineBrain Brain => _brain;
    }
}