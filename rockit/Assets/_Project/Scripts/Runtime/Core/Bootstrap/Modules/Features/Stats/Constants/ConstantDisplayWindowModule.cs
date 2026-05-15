using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Constants.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats.Constants
{
    public sealed class ConstantDisplayWindowModule : BaseModule<ConstantDisplayWindowModule>
    {
        public ConstantDisplayWindowModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendConstantDisplayWindowRequestsByConstantsDisplaysServiceSystem>();
            BindSystem<PrepareConstantDisplayWindowServiceOnRebuildConstantDisplayWindowRequestSystem>();
            BindSystem<UpdateConstantDisplayWindowOnRebuildConstantDisplayWindowRequestSystem>();
        }
    }
}