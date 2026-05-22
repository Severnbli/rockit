using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Constants.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats.Constants
{
    public sealed class ConstantsSceneModule : BaseModule<ConstantsSceneModule>
    {
        public ConstantsSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<ManageConstantInvestigatedStatusByStorageOnRunSystem>();
            BindSystem<ManageConstantDisplayActiveStatusByPlayerLocatorOnRunSystem>();
            BindSystem<UpdateConstantsDisplaysServiceNearestConstantIdOnRunSystem>();
            BindSystem<UpdateConstantImproversCoinsAmountOnRunSystem>();
            BindSystem<ImproveConstantOnConstantImproverClickedSystem>();
            BindSystem<SendConstantTriggeredRequestOnPlayerTriggerEnterRequestSystem>();
            BindSystem<DisableConstantColliderOnConstantTriggeredRequestSystem>();
            BindSystem<CollectConstantOnConstantTriggeredRequestSystem>();
            BindSystem<DisableConstantOnInitializeRequestSystem>();
        }
    }
}