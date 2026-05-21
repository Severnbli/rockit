using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class PersistLevelsStatsServiceCachedInvestigatedConstantsOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsStatsService _lsService;
        private readonly DataProvider _dProvider;

        public PersistLevelsStatsServiceCachedInvestigatedConstantsOnLevelCompletedRequestSystem(
            LevelsStatsService lsService, DataProvider dProvider)
        {
            _lsService = lsService;
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;

            var statsData = _dProvider.StatsData;
            
            foreach (var kvp in _lsService.CachedInvestigatedConstants)
            {
                statsData.InvestigatedConstants.TryAdd(kvp.Key, kvp.Value);
            }
            
            _dProvider.SaveTracked();
        }
    }
}