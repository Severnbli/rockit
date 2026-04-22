using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms
{
    public sealed class PlatformsSharedModule : BaseModule<PlatformsSharedModule>
    {
        public PlatformsSharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<LoadPlatformStartStatesOnInitializeRequestSystem>();
        }
    }
}