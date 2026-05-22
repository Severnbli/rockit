using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class IconsModule : BaseModule<IconsModule>
    {
        public IconsModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<StarIconFactory>().ToSelf().AsSingle();
            Container.Bind<CoinIconFactory>().ToSelf().AsSingle();
            Container.Bind<AnimatableStarIconFactory>().ToSelf().AsSingle();
        }
    }
}