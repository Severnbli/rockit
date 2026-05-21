using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Economy.Coins.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Economy
{
    public static class CoinsUtils
    {
        public static ProtoEntity CreateWasteCoinsRequest(RequestsAspect aspect, WasteCoinsRequest prepared)
        {
            return aspect.CreateRequest(aspect.CoinsRequestsAspect.WasteCoinsRequestPool, prepared: prepared);
        }

        public static ProtoEntity CreateCoinTriggeredRequest(RequestsAspect aspect, ProtoPackedEntityWithWorld packed, 
            CoinTriggeredRequest prepared)
        {
            return aspect.CreateRequest(aspect.CoinsRequestsAspect.CoinTriggeredRequestPool, packed, prepared: prepared);
        }

        public static bool CoinsEnoughToBuy(DataProvider dProvider, int coinsAmount)
        {
            return dProvider.EconomyData.CoinsQuantity >= coinsAmount;
        }
    }
}