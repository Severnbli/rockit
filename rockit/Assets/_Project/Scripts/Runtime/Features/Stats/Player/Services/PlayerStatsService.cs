using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public float WalkFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float JumpFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float DashFactorModifier = StatsSharedContracts.DefaultFloatFactorModifier;
    }
}