using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Economy.Coins.Configs;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class UpdateEconomyDataCoinsQuantityOnCoinCollectedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly CoinsRequestsAspect _crAspect;
        private readonly CoinsConfig _cConfig;
        private readonly DataProvider _dProvider;

        public UpdateEconomyDataCoinsQuantityOnCoinCollectedRequestSystem(CoinsConfig cConfig, DataProvider dProvider)
        {
            _cConfig = cConfig;
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_crAspect.CoinCollectedRequests.IsEmptySlow()) return;

            var count = _crAspect.CoinCollectedRequests.LenSlow();
            _dProvider.EconomyData.CoinsQuantity += _cConfig.CoinsPerCollectedCoin * count;
            _dProvider.SaveTracked();
        }
    }
}