using _Project.Scripts.Runtime.Features.Stats.Shared;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Services
{
    public sealed class PlayerStatsService
    {
        public float WalkModifier = StatsSharedContracts.DefaultModifier;
        public float JumpModifier = StatsSharedContracts.DefaultModifier;
        public float DashModifier = StatsSharedContracts.DefaultModifier;
    }
}