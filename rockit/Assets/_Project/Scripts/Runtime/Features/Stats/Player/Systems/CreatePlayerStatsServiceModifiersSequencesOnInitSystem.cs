using _Project.Scripts.Runtime.Features.Economy.Coins.Types;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Tools;
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
                out var wfmElement);
            _psService.WalkFactorModifierObserver = new SequenceElementObserver<IndexableFloatPaidWithCoins>
            {
                Element = wfmElement
            };
            
            StatsSharedUtils.CreateModifierSequence(_psConfig.JumpFactorUpdates,
                out var jfmElement);
            _psService.JumpFactorModifierObserver = new SequenceElementObserver<IndexableFloatPaidWithCoins>
            {
                Element = jfmElement
            };
            
            StatsSharedUtils.CreateModifierSequence(_psConfig.DashFactorUpdates,
                out var dfmElement);
            _psService.DashFactorModifierObserver = new SequenceElementObserver<IndexableFloatPaidWithCoins>
            {
                Element = dfmElement
            };
            
            StatsSharedUtils.CreateModifierSequence(_psConfig.DashQuantityUpdates,
                out var dqmElement);
            _psService.DashQuantityModifierObserver = new SequenceElementObserver<IndexableQuantityPaidWithCoins>
            {
                Element = dqmElement
            };

            PaidWithCoins a = _psService.DashQuantityModifierObserver.Element.Value;
        }
    }
}