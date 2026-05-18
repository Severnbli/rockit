using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Input.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Input
{
    public sealed class InputProjectModule : BaseModule<InputProjectModule>
    {
        public InputProjectModule(IDomain domain) : base(domain)
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
            
            BindSystem<DisablePlayerInputOnInitDestroySystem>();
            BindSystem<DisablePlatformsInputOnInitDestroySystem>();
            BindSystem<EnablePlayerInputOnRequestSystem>();
            BindSystem<DisablePlayerInputOnRequestSystem>();
            BindSystem<EnablePlatformsInputOnRequestSystem>();
            BindSystem<DisablePlatformsInputOnRequestSystem>();
            BindSystem<PlatformsInputServiceUpdateSystem>();
            BindSystem<PlayerInputServiceUpdateSystem>();
        }
    }
}