using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using TMPro;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Systems
{
    public sealed class UpdateLocalizationDropdownSelectorsOnLocalizationUpdatedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DI] private readonly DropdownsAspect _dAspect;
        private readonly LocalizationService _lService;

        public UpdateLocalizationDropdownSelectorsOnLocalizationUpdatedRequestSystem(LocalizationService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            if (_lrAspect.LocalizationUpdatedRequests.IsEmptySlow() 
                || _dAspect.DropdownLocalizationSelectors.IsEmptySlow()) return;

            var list = new List<TMP_Dropdown.OptionData>();

            var currId = 0;
            var selectedId = 0;
            
            foreach (var mapKvp in _lService.IdLanguageCodeMapper)
            {
                var langCode = mapKvp.Value;

                if (_lService.CurrLang.LanguageCode == langCode)
                {
                    selectedId = currId;
                }
                
                list.Add(new TMP_Dropdown.OptionData
                {
                    text = _lService.GetString(langCode, LocalizationEntriesContracts.LanguageNameS),
                });
                
                currId++;
            }

            foreach (var e in _dAspect.DropdownLocalizationSelectors)
            {
                ref var dComponent = ref _dAspect.DropdownComponentPool.Get(e);
                var dropdown = dComponent.Dropdown;

                dropdown.options = list;
                dropdown.SetValueWithoutNotify(selectedId);
                dropdown.RefreshShownValue();
            }
        }
    }
}