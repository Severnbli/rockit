using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure.Localization
{
    public sealed class LocalizationProjectModule : BaseModule<LocalizationProjectModule>
    {
        public LocalizationProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<LocalizationService>();
            BindService<LocalizationDropdownService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<LoadLocalizationServiceOnInitSystem>();
            BindSystem<LoadLocalizationDropdownServiceOnInitSystem>();
            BindSystem<ChangeLanguageOnChangeLanguageRequestSystem>();
            BindSystem<UpdateLocalizationDropdownServiceCurrentIdOnChangeLanguageRequestSystem>();
        }
    }
}