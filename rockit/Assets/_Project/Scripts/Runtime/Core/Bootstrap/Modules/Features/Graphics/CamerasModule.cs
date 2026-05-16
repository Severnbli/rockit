using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class CamerasModule : BaseModule<CamerasModule>
    {
        public CamerasModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<CamerasService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchCameraOnSwitchCameraRequestSystem>();
        }
    }
}