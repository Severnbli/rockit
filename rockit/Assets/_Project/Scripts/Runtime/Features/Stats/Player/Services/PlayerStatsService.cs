using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Shared;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public float WalkFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float JumpFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float DashFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public int DashQuantityModifier = StatsSharedContracts.DefaultIntQuantityModifier;
        
        public SequenceElementObserver<IndexableFactorPaidWithCoins> WalkFactorModifierObserver;
        public SequenceElementObserver<IndexableFactorPaidWithCoins> JumpFactorModifierObserver;
        public SequenceElementObserver<IndexableFactorPaidWithCoins> DashFactorModifierObserver;
        public SequenceElementObserver<IndexableQuantityPaidWithCoins> DashQuantityModifierObserver;
    }
}