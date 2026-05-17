using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Menu.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows
{
    public sealed class MenuSceneWindowsModule : BaseModule<MenuSceneWindowsModule>
    {
        public MenuSceneWindowsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchToLevelSelectionStateOnClickedLevelSelectionSystem>();
            BindSystem<SwitchToMenuStateOnClickedMenuSystem>();
            BindSystem<SwitchToCollectionStateOnClickedCollectionSystem>();
        }
    }
}