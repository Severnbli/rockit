using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Economy.Coins.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Economy.Coins
{
    public sealed class CoinsSceneModule : BaseModule<CoinsSceneModule>
    {
        public CoinsSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<DisableCollectedCoinOnInitializeRequestSystem>();
            BindSystem<UpdateCoinsTextUIOutputWithCoinsAmountSystem>();
            BindSystem<ManageButtonsInteractableStatusByCoinsAmountSystem>();
            BindSystem<SendWasteCoinsAmountOnClickedCoinsAmountsSystem>();
            BindSystem<UpdateCoinsTotalizersTextUisOnRunSystem>();
            BindSystem<SendCoinTriggeredRequestOnPlayerTriggerEnterRequestSystem>();
        }
    }
}