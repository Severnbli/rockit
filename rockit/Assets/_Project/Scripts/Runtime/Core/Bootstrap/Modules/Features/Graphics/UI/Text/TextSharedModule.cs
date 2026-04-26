using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Text
{
    public sealed class TextSharedModule : BaseModule<TextSharedModule>
    {
        public TextSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateTextUiOnUpdateLocalizationItemRequestSystem>();
        }
    }
}