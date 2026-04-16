using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Configs
{
    public class SharedMovingConfig : ScriptableObjectAutoInstaller<SharedMovingConfig>
    {
        [SerializeField] private float _coyoteTime = 0.1f;
        [SerializeField] private float _jumpBufferingTime = 0.1f;
        
        public float CoyoteTime => _coyoteTime;
        public float JumpBufferingTime => _jumpBufferingTime;
    }
}