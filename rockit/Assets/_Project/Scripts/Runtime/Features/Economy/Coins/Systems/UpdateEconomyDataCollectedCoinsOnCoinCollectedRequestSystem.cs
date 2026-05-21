using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Economy;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class UpdateEconomyDataCollectedCoinsOnCoinCollectedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly CoinsRequestsAspect _crAspect;
        private readonly DataProvider _dProvider;

        public UpdateEconomyDataCollectedCoinsOnCoinCollectedRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_crAspect.CoinCollectedRequests.IsEmptySlow()) return;

            var dict = _dProvider.EconomyData.CollectedCoins;
            foreach (var e in _crAspect.CoinCollectedRequests)
            {
                ref var ccRequest = ref _crAspect.CoinCollectedRequestPool.Get(e);
                dict.TryAdd(ccRequest.CoinId, new CoinData());
            }
            _dProvider.SaveTracked();
        }
    }
}