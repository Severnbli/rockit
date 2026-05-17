using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class DropdownsModule : BaseModule<DropdownsModule>
    {
        public DropdownsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateLocalizationDropdownSelectorsOnLocalizationUpdatedRequestSystem>();
            BindSystem<SendChangeLanguageRequestOnDropdownChangeLocalizationSelectorsSystem>();
        }
    }
}