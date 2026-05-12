using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class UISharedModule : BaseModule<UISharedModule>
    {
        public UISharedModule(IDomain domain) : base(domain)
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
            
            BindSystem<RemoveClickedTagOnRunSystem>();
            BindSystem<SetClickedTagOnClickEventSystem>();
            BindSystem<SendCloseAppRequestOnClickedCloseAppItemSystem>();
            BindSystem<OpenOpenableOnClickedItemSystem>();
            BindSystem<CloseClosableOnClickedItemSystem>();
            BindSystem<CreateLevelButtonsOnCreateLevelButtonsRequestSystem>();
            BindSystem<SetLevelIdToLoadOnLevelItemOpenerClickedSystem>();
            BindSystem<SendSwitchSceneRequestOnClickedMenuSceneLoaderSystem>();
            BindSystem<SendSwitchSceneRequestOnClickedGameSceneLoaderSystem>();
        }
    }
}