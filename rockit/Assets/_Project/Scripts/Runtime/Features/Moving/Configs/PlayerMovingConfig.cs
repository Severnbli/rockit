using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Configs
{
    public class PlayerMovingConfig : ScriptableObjectAutoInstaller<PlayerMovingConfig>
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _jumpPower = 4f;
        
        public float WalkSpeed => _walkSpeed;
        public float JumpPower => _jumpPower;
    }
}