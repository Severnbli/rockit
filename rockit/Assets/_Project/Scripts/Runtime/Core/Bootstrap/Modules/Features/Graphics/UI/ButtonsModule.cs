using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class ButtonsModule : BaseModule<ButtonsModule>
    {
        public ButtonsModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<LevelButtonViewFactory>().ToSelf().AsSingle();
        }
    }
}