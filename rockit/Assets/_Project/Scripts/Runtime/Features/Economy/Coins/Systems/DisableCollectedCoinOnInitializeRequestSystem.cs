using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class DisableCollectedCoinOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DI] private CoinsAspect _cAspect;
        private readonly DataProvider _dProvider;
        private ProtoWorld _world;

        public DisableCollectedCoinOnInitializeRequestSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_rAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cAspect.Coins.Has(tarE)) continue;
                
                ref var cComponent = ref _cAspect.CoinComponentPool.Get(tarE);

                if (!_dProvider.EconomyData.CollectedCoins.ContainsKey(cComponent.Id)) continue;

                var packed = _world.PackEntityWithWorld(tarE);
                SharedUtils.CreateDisableRequest(_rAspect, packed);
            }
        }
    }
}