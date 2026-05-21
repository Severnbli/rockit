using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Economy.Coins.Requests;
using _Project.Scripts.Runtime.Features.Player;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features.Economy;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class ProcessCoinTriggeredOnPlayerTriggerEnterRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly CoinsAspect _cAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public ProcessCoinTriggeredOnPlayerTriggerEnterRequestSystem(SharedIndexService siService)
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

                SendCoinCollectedRequest(tarE);
                CreateDisableRequest(tarE);
            }
        }

        private void SendCoinCollectedRequest(ProtoEntity tarE)
        {
            ref var cComponent = ref _cAspect.CoinComponentPool.Get(tarE);

            var prepared = new CoinCollectedRequest
            {
                CoinId = cComponent.Id
            };
            CoinsUtils.CreateCoinCollectedRequest(_rAspect, prepared);
        }

        private void CreateDisableRequest(ProtoEntity tarE)
        {
            var packed = _world.PackEntityWithWorld(tarE);
            SharedUtils.CreateDisableRequest(_rAspect, packed);
        }
    }
}