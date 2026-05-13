using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public float WalkModifier = StatsSharedContracts.DefaultFloatModifier;
        public float JumpModifier = StatsSharedContracts.DefaultFloatModifier;
        public float DashModifier = StatsSharedContracts.DefaultFloatModifier;
        
    }
}