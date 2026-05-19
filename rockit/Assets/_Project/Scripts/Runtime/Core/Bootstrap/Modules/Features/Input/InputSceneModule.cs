using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Input.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Input
{
    public sealed class InputSceneModule : BaseModule<InputSceneModule>
    {
        public InputSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
            BindSystem<OpenClosePlayerInputWindowOnPlayerInputEnabledDisabledSystem>();
            BindSystem<OpenClosePlatformsInputWindowOnPlatformsInputEnabledDisabledSystem>();
            BindSystem<UpdatePlatformsInputWindowButtonsInteractableStatusByPlatformsInputServiceProfileSystem>();
#endif
        }
    }
}