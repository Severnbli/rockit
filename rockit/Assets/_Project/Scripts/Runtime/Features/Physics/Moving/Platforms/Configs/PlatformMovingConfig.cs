using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Configs
{
    public class PlatformMovingConfig<T> : ScriptableObjectAutoInstaller<T> 
        where T : PlatformMovingConfig<T>
    {
        [SerializeField] private float _posChangeSpeed = 5f;
        [SerializeField] private float _rotChangeSpeed = 3f;
        [SerializeField] private float _scaleChangeSpeed = 2f;
        
        public float PosChangeSpeed => _posChangeSpeed;
        public float RotChangeSpeed => _rotChangeSpeed;
        public float ScaleChangeSpeed => _scaleChangeSpeed;
    }
}