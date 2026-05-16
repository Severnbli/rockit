using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class UpdateCoinsTotalizersTextUisOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly CoinsAspect _cAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        private readonly DataProvider _dProvider;

        public UpdateCoinsTotalizersTextUisOnRunSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            var eData = _dProvider.EconomyData;
            
            foreach (var e in _cAspect.CoinsTotalizerTextUis)
            {
                ref var tuComponent = ref _tsAspect.TextUiComponentPool.Get(e);
                tuComponent.Text.text = eData.CoinsQuantity.ToString();
            }
        }
    }
}