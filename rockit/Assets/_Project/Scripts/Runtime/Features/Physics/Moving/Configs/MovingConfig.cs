using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Configs
{
    public class MovingConfig<T> : ScriptableObjectAutoInstaller<T> where T : MovingConfig<T>
    {
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _jumpPower = 4f;
        [SerializeField] private float _dashPower = 4f;
        [SerializeField] private int _airDashes = 1;
        [SerializeField] private float _dashTimeout = 0.5f;
        
        public float WalkSpeed => _walkSpeed;
        public float JumpPower => _jumpPower;
        public float DashPower => _dashPower;
        public int AirDashes => _airDashes;
        public float DashTimeout => _dashTimeout;
    }
}