using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Input.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features
{
    public sealed class InputModule : BaseModule<InputModule>
    {
        public InputModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<PlayerInputService>();
            BindService<PlatformsInputService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendEnablePlayerInputRequestOnInitSystem>();
            BindSystem<SendEnablePlatformsInputRequestOnInitSystem>();
            BindSystem<SendDisablePlayerInputRequestOnDestroySystem>();
            BindSystem<SendDisablePlatformsInputRequestOnDestroySystem>();
            BindSystem<EnablePlayerInputOnRequestSystem>();
            BindSystem<DisablePlayerInputOnRequestSystem>();
            BindSystem<EnablePlatformsInputOnRequestSystem>();
            BindSystem<DisablePlatformsInputOnRequestSystem>();
        }
    }
}