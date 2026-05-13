using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public float WalkModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float JumpModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        public float DashModifier = StatsSharedContracts.DefaultFloatFactorModifier;
        
    }
}