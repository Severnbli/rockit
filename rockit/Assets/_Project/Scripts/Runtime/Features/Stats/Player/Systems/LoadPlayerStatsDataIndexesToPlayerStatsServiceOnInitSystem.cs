using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Utils.Shared;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public class LoadPlayerStatsDataIndexesToPlayerStatsServiceOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerStatsService _psService;
        private readonly DataProvider _dProvider;

        public LoadPlayerStatsDataIndexesToPlayerStatsServiceOnInitSystem(PlayerStatsService psService,
            DataProvider dProvider)
        {
            _psService = psService;
            _dProvider = dProvider;
        }

        public void Init(IProtoSystems systems)
        {
            var psData = _dProvider.StatsData.PlayerStatsData;
            
            if (SequenceElementUtils.TryFind(
                    _psService.WalkFactorModifierElement, 
                    x => x.Index == psData.WalkFactorUpdateIndex,
                    out var wfmResult))
            {
                _psService.WalkFactorModifierElement = wfmResult;
            }
            
            if (SequenceElementUtils.TryFind(
                    _psService.JumpFactorModifierElement, 
                    x => x.Index == psData.JumpFactorUpdateIndex,
                    out var jfmResult))
            {
                _psService.JumpFactorModifierElement = jfmResult;
            }
            
            if (SequenceElementUtils.TryFind(
                    _psService.DashFactorModifierElement, 
                    x => x.Index == psData.DashFactorUpdateIndex,
                    out var dfmResult))
            {
                _psService.DashFactorModifierElement = dfmResult;
            }
            
            if (SequenceElementUtils.TryFind(
                    _psService.DashQuantityModifierElement, 
                    x => x.Index == psData.DashQuantityUpdateIndex,
                    out var dqmResult))
            {
                _psService.DashQuantityModifierElement = dqmResult;
            }
        }
    }
}