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
        
        public SequenceElementObserver<IndexableFloatPaidWithCoins> WalkFactorModifierObserver;
        public SequenceElementObserver<IndexableFloatPaidWithCoins> JumpFactorModifierObserver;
        public SequenceElementObserver<IndexableFloatPaidWithCoins> DashFactorModifierObserver;
        public SequenceElementObserver<IndexableFloatPaidWithCoins> DashQuantityModifierObserver;
    }
}