using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure.Localization
{
    public sealed class LocalizationSceneModule : BaseModule<LocalizationSceneModule>
    {
        public LocalizationSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendUpdateLocalizationItemRequestOnLocalizationUpdatedRequestSystem>();
        }
    }
}