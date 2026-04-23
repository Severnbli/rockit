using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class LocalizationModule : BaseModule<LocalizationModule>
    {
        public LocalizationModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<LocalizationService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<LoadLocalizationServiceOnInitSystem>();
            BindSystem<ChangeLanguageOnChangeLanguageRequestSystem>();
        }
    }
}