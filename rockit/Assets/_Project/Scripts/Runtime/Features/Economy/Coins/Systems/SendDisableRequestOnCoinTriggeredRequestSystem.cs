using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class SendDisableRequestOnCoinTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly CoinsRequestsAspect _crAspect;
        
        public void Run()
        {
            foreach (var reqE in _crAspect.CoinTriggeredRequests)
            {
                ref var rComponent = ref _rAspect.CoreRequestsAspect.RequestComponentPool.Get(reqE);
                SharedUtils.CreateDisableRequest(_rAspect, rComponent.Entity);
            }
        }
    }
}