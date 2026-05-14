using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Constants.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Animations
{
    public sealed class ConstantsAnimationsModule : BaseModule<ConstantsAnimationsModule>
    {
        public ConstantsAnimationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateConstantDisplayAnimatorActiveBoolByConstantDisplayActiveTagExistenceSystem>();
            BindSystem<UpdateConstantDisplayAnimatorInvestigatedBoolByConstantInvestigatedTagExistenceSystem>();
            BindSystem<UpdateConstantDisplayAnimatorActiveBoolByConstantDisplayActiveStatusSystem>();
        }
    }
}