using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Configs
{
    public sealed class PlatformParticlesConfig : ScriptableObjectAutoInstaller<PlatformParticlesConfig>
    {
        [SerializeField] private GameObject _positionPrefab;
        [SerializeField] private GameObject _rotationPrefab;
        [SerializeField] private GameObject _scalePrefab;
        
        public GameObject PositionPrefab => _positionPrefab;
        public GameObject RotationPrefab => _rotationPrefab;
        public GameObject ScalePrefab => _scalePrefab;
    }
}