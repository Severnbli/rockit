using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Project.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows
{
    public sealed class ProjectWindowsModule : BaseModule<ProjectWindowsModule>
    {
        public ProjectWindowsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<UpdateControlsWindowInfoOnInitSystem>();
            BindSystem<UpdateControlsWindowInfoOnLocalizationUpdatedRequestSystem>();
            BindSystem<UpdateLoadingWindowTextOnInitSystem>();
            BindSystem<UpdateLoadingWindowTextOnLocalizationUpdatedRequestSystem>();
        }
    }
}