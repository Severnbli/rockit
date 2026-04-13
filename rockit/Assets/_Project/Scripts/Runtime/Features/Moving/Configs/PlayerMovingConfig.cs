using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Configs
{
    public class PlayerMovingConfig : ScriptableObjectAutoInstaller<PlayerMovingConfig>
    {
        [SerializeField] private float _walkSpeed;
        
        public float WalkSpeed => _walkSpeed;
    }
}