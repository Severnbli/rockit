using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Configs
{
    public sealed class PlayerStatsConfig : ScriptableObjectAutoInstaller<PlayerStatsConfig>
    {
        [SerializeField] private FactorPaidWithCoins[] _walkFactorUpdates;
        [SerializeField] private FactorPaidWithCoins[] _jumpFactorUpdates;
        [SerializeField] private FactorPaidWithCoins[] _dashFactorUpdates;
        [SerializeField] private QuantityPaidWithCoins[] _dashQuantityUpdates;
        
        public FactorPaidWithCoins[] WalkFactorUpdates => _walkFactorUpdates;
        public FactorPaidWithCoins[] JumpFactorUpdates => _jumpFactorUpdates;
        public FactorPaidWithCoins[] DashFactorUpdates => _dashFactorUpdates;
        public QuantityPaidWithCoins[] DashQuantityUpdates => _dashQuantityUpdates;
    }
}