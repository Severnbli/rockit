using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Buttons
{
    public sealed class ButtonsSharedModule : BaseModule<ButtonsSharedModule>
    {
        public ButtonsSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendCloseAppRequestOnCloseButtonClickedSystem>();
        }
    }
}