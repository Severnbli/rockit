using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Configs
{
    public class SharedMovingConfig : ScriptableObjectAutoInstaller<SharedMovingConfig>
    {
        [SerializeField] private float _coyoteTime = 0.1f;
        
        public float CoyoteTime => _coyoteTime;
    }
}