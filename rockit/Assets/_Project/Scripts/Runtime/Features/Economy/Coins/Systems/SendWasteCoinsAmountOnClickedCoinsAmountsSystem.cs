using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Economy.Coins.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features.Economy;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class SendWasteCoinsAmountOnClickedCoinsAmountsSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly CoinsAspect _cAspect;
        
        public void Run()
        {
            foreach (var e in _cAspect.ClickedCoinsAmounts)
            {
                ref var caComponent = ref _cAspect.CoinsAmountComponentPool.Get(e);

                var prepared = new WasteCoinsRequest
                {
                    Amount = caComponent.Amount
                };
                CoinsUtils.CreateWasteCoinsRequest(_rAspect, prepared);
            }
        }
    }
}