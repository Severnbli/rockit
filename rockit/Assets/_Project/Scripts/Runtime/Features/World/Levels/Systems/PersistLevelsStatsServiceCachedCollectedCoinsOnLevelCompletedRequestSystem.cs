using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Economy.Coins.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class PersistLevelsStatsServiceCachedCollectedCoinsOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsStatsService _lsService;
        private readonly DataProvider _dProvider;
        private readonly CoinsConfig _cConfig;

        public PersistLevelsStatsServiceCachedCollectedCoinsOnLevelCompletedRequestSystem(LevelsStatsService lsService, 
            DataProvider dProvider, CoinsConfig cConfig)
        {
            _lsService = lsService;
            _dProvider = dProvider;
            _cConfig = cConfig;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;

            var economyData = _dProvider.EconomyData;

            foreach (var kvp in _lsService.CachedCollectedCoins)
            {
                if (!economyData.CollectedCoins.TryAdd(kvp.Key, kvp.Value)) continue;

                economyData.CoinsQuantity += _cConfig.CoinsPerCollectedCoin;
            }
            
            _dProvider.SaveTracked();
        }
    }
}