using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Configs
{
    public class PlayerStatsConfig : ScriptableObjectAutoInstaller<PlayerStatsConfig>
    {
        [SerializeField] private float[] _walkModifiers;
        [SerializeField] private float[] _jumpModifiers;
        [SerializeField] private float[] _dashModifiers;
        
        public float[] WalkModifiers => _walkModifiers;
        public float[] JumpModifiers => _jumpModifiers;
        public float[] DashModifiers => _dashModifiers;
    }
}