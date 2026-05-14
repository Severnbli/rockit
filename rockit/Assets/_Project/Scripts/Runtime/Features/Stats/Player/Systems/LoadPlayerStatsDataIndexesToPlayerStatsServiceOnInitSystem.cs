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
            
            _psService.WalkFactorModifierObserver.GoTo(x => x.Index == psData.WalkFactorUpdateIndex);
            _psService.JumpFactorModifierObserver.GoTo(x => x.Index == psData.JumpFactorUpdateIndex);
            _psService.DashFactorModifierObserver.GoTo(x => x.Index == psData.DashFactorUpdateIndex);
            _psService.DashQuantityModifierObserver.GoTo(x => x.Index == psData.DashQuantityUpdateIndex);
        }
    }
}