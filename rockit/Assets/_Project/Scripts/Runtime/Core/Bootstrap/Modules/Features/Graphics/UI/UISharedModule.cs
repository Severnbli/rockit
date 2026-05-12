using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI
{
    public sealed class UISharedModule : BaseModule<UISharedModule>
    {
        public UISharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<RemoveClickedTagOnRunSystem>();
            BindSystem<SetClickedTagOnClickEventSystem>();
            BindSystem<RemoveClickedTagFromInactiveUIElements>();
            BindSystem<SendCloseAppRequestOnClickedCloseAppItemSystem>();
            BindSystem<OpenOpenableOnClickedItemSystem>();
            BindSystem<CloseClosableOnClickedItemSystem>();
            BindSystem<SendLoadLevelRequestOnClickedLevelItemSceneLoaderSystem>();
            BindSystem<SendSwitchSceneRequestOnClickedMenuSceneLoaderSystem>();
            BindSystem<SendSwitchSceneRequestOnClickedGameSceneLoaderSystem>();
        }
    }
}