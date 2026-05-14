using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Configs
{
    public sealed class PlayerStatsConfig : ScriptableObjectAutoInstaller<PlayerStatsConfig>
    {
        [SerializeField] private FloatPaidWithCoins[] _walkFactorUpdates;
        [SerializeField] private FloatPaidWithCoins[] _jumpFactorUpdates;
        [SerializeField] private FloatPaidWithCoins[] _dashFactorUpdates;
        [SerializeField] private FloatPaidWithCoins[] _dashQuantityUpdates;
        
        public FloatPaidWithCoins[] WalkFactorUpdates => _walkFactorUpdates;
        public FloatPaidWithCoins[] JumpFactorUpdates => _jumpFactorUpdates;
        public FloatPaidWithCoins[] DashFactorUpdates => _dashFactorUpdates;
        public FloatPaidWithCoins[] DashQuantityUpdates => _dashQuantityUpdates;
    }
}