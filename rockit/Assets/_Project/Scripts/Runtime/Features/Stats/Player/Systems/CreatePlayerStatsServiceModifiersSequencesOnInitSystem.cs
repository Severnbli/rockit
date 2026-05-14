using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class CreatePlayerStatsServiceModifiersSequencesOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerStatsService _psService;
        private readonly PlayerStatsConfig _psConfig;

        public CreatePlayerStatsServiceModifiersSequencesOnInitSystem(PlayerStatsService psService,
            PlayerStatsConfig psConfig)
        {
            _psService = psService;
            _psConfig = psConfig;
        }

        public void Init(IProtoSystems systems)
        {
            StatsSharedUtils.CreateModifierSequence(_psConfig.WalkFactorUpdates,
                out _psService.WalkFactorModifierElement);
            StatsSharedUtils.CreateModifierSequence(_psConfig.JumpFactorUpdates,
                out _psService.JumpFactorModifierElement);
            StatsSharedUtils.CreateModifierSequence(_psConfig.DashFactorUpdates,
                out _psService.DashFactorModifierElement);
            StatsSharedUtils.CreateModifierSequence(_psConfig.DashQuantityUpdates,
                out _psService.DashQuantityModifierElement);
        }
    }
}