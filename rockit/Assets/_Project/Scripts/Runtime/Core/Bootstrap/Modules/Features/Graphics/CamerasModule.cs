using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Services;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Systems;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics
{
    public sealed class CamerasModule : BaseModule<CamerasModule>
    {
        public CamerasModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<ICameraSwitchAwaiter>().To<CameraSwitchAwaiter>().AsSingle();
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<CamerasService>();
            BindService<CamerasSwitchService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchCameraOnSwitchCameraRequestSystem>();
            BindSystem<CamerasSwitchServiceOnRunObserverSystem>();
        }
    }
}