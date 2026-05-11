using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class UIProjectModule : BaseModule<UIProjectModule>
    {
        public UIProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<StarIconFactory>().ToSelf().AsSingle();
            Container.Bind<LevelButtonFactory>().ToSelf().AsSingle();
        }

        protected override void BindSystems()
        {
            base.BindSystems();

            BindSystem<CreateAllLevelButtonsOnCreateAllLevelButtonsRequestSystem>();
            BindSystem<CreateLevelButtonOnCreateLevelButtonRequestSystem>();
        }
    }
}