using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Configs
{
    public class SharedPlatformMovingConfig : ScriptableObjectAutoInstaller<SharedPlatformMovingConfig>
    {
        [SerializeField] private float _posTolerance = 0.05f;
        [SerializeField] private float _rotTolerance = 0.05f;
        [SerializeField] private float _scaleTolerance = 0.05f;

        public float PosTolerance => _posTolerance;
        public float RotTolerance => _rotTolerance;
        public float ScaleTolerance => _scaleTolerance;
    }
}