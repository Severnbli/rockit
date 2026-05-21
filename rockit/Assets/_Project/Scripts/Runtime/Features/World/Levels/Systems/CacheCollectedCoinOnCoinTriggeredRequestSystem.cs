using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Economy;
using _Project.Scripts.Runtime.Features.Economy.Coins;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class CacheCollectedCoinOnCoinTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly CoinsRequestsAspect _crAspect;
        private readonly LevelsStatsService _lsService;

        public CacheCollectedCoinOnCoinTriggeredRequestSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            foreach (var e in _crAspect.CoinTriggeredRequests)
            {
                ref var ctRequest = ref _crAspect.CoinTriggeredRequestPool.Get(e);
                _lsService.CachedCollectedCoins.TryAdd(ctRequest.CoinId, new CoinData());
            }
        }
    }
}