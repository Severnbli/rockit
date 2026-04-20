using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs
{
    public class SharedCharacterMovingConfig : ScriptableObjectAutoInstaller<SharedCharacterMovingConfig>
    {
        [SerializeField] private float _coyoteTime = 0.1f;
        [SerializeField] private float _jumpBufferingTime = 0.1f;
        [SerializeField] private float _sideCollisionTolerance = 0.4f;
        
        public float CoyoteTime => _coyoteTime;
        public float JumpBufferingTime => _jumpBufferingTime;
        public float SideCollisionTolerance => _sideCollisionTolerance;
    }
}