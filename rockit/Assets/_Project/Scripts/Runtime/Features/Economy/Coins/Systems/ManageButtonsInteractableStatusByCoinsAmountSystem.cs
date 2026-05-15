using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons;
using _Project.Scripts.Runtime.Shared.Utils.Features.Economy;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Economy.Coins.Systems
{
    public sealed class ManageButtonsInteractableStatusByCoinsAmountSystem : IProtoRunSystem
    {
        [DI] private readonly CoinsAspect _cAspect;
        [DI] private readonly ButtonsAspect _bAspect;
        private readonly DataProvider _dProvider;

        public ManageButtonsInteractableStatusByCoinsAmountSystem(DataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            foreach (var e in _cAspect.CoinsAmountButtons)
            {
                ref var caComponent = ref _cAspect.CoinsAmountComponentPool.Get(e);
                ref var bComponent = ref _bAspect.ButtonComponentPool.Get(e);
                bComponent.Button.interactable = CoinsUtils.CoinsEnoughToBuy(_dProvider, caComponent.Amount);
            }
        }
    }
}