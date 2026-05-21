using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Economy.Coins.Requests;
using _Project.Scripts.Runtime.Features.Player;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Economy;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class SendCoinTriggeredRequestOnPlayerTriggerEnterRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly CoinsAspect _cAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public SendCoinTriggeredRequestOnPlayerTriggerEnterRequestSystem(SharedIndexService siService)
        {
            _siService = siService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var reqE in _prAspect.PlayerEnterTriggerRequests)
            {
                ref var petRequest = ref _prAspect.PlayerEnterTriggerRequestPool.Get(reqE);
                if (!goIndex.TryGetEntityFromIndex(petRequest.Collider.gameObject, _world, out var tarE)) continue;
                if (!_cAspect.Coins.Has(tarE)) continue;

                ref var cComponent = ref _cAspect.CoinComponentPool.Get(tarE);

                var prepared = new CoinTriggeredRequest
                {
                    CoinId = cComponent.Id
                };
                var packed = _world.PackEntityWithWorld(tarE);
            
                CoinsUtils.CreateCoinTriggeredRequest(_rAspect, packed, prepared);
            }
        }
    }
}