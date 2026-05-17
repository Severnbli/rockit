using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class UpdateLocalizationDropdownServiceCurrentIdOnChangeLanguageRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        private readonly LocalizationDropdownService _ldService;
        private readonly LocalizationService _lService;

        public UpdateLocalizationDropdownServiceCurrentIdOnChangeLanguageRequestSystem(
            LocalizationDropdownService ldService, LocalizationService lService)
        {
            _ldService = ldService;
            _lService = lService;
        }

        public void Run()
        {
            if (_lrAspect.ChangeLanguageRequests.IsEmptySlow()) return;

            var selectedId = 0;
            foreach (var kvp in _ldService.IdLangCodeMapper)
            {
                if (kvp.Value != _lService.CurrLang.LanguageCode) continue;
                
                selectedId = kvp.Key;
                break;
            }
            
            _ldService.CurrentId = selectedId;
        }
    }
}