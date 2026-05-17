using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows
{
    public sealed class SharedSceneWindowsModule : BaseModule<SharedSceneWindowsModule>
    {
        public SharedSceneWindowsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchToSettingsStateOnClickedSettingsSystem>();
        }
    }
}