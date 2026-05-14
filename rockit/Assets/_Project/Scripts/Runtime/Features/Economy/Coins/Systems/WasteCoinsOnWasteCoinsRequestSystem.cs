using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class WasteCoinsOnWasteCoinsRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly CoinsRequestsAspect _crAspect;
        private readonly DataProvider _dProvider;

        public WasteCoinsOnWasteCoinsRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            foreach (var e in _crAspect.WasteCoinsRequests)
            {
                ref var wcRequest = ref _crAspect.WasteCoinsRequestPool.Get(e);
                _dProvider.EconomyData.CoinsQuantity -= wcRequest.Amount;
                StorageUtils.CreateSaveTrackedDataRequest(_rAspect);
            }
        }
    }
}