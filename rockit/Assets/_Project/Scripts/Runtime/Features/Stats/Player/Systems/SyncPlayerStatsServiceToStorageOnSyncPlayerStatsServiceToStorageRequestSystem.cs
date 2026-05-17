using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public class SyncPlayerStatsServiceToStorageOnSyncPlayerStatsServiceToStorageRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlayerStatsRequestsAspect _psrAspect;
        private readonly PlayerStatsService _psService;
        private readonly DataProvider _dProvider;

        public SyncPlayerStatsServiceToStorageOnSyncPlayerStatsServiceToStorageRequestSystem(
            PlayerStatsService psService, DataProvider dProvider)
        {
            _psService = psService;
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_psrAspect.SyncPlayerStatsServiceToStorageRequests.IsEmptySlow()) return;

            var psData = _dProvider.StatsData.PlayerStatsData;
            psData.WalkFactorUpdateIndex = _psService.WalkFactorModifierObserver.Element.Value.Index;
            psData.JumpFactorUpdateIndex = _psService.JumpFactorModifierObserver.Element.Value.Index;
            psData.DashFactorUpdateIndex = _psService.DashFactorModifierObserver.Element.Value.Index;
            psData.DashQuantityUpdateIndex = _psService.DashQuantityModifierObserver.Element.Value.Index;
            
            _dProvider.SaveTracked();
        }
    }
}