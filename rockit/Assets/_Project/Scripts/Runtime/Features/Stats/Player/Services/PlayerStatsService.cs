using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Shared.Tools;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public SequenceElement<FactorPaidWithCoinsElement> WalkFactorModifier;
        public SequenceElement<FactorPaidWithCoinsElement> JumpFactorModifier;
        public SequenceElement<FactorPaidWithCoinsElement> DashFactorModifier;
        public SequenceElement<QuantityPaidWithCoinsElement> DashQuantityModifier;
    }
}