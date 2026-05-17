using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using TMPro;

namespace _Project.Scripts.Runtime.Shared.Extensions.Infrastructure
{
    public static class LocalizationExtensions
    {
        public static string GetString(this LocalizationService service, string key)
        {
            if (service.CurrLang == null || !service.CurrLang.Entries.TryGetValue(key, out var entry)) return "";
            return entry.String;
        }

        public static string GetString(this LocalizationService service, string langCode, string key)
        {
            if (!service.LangData.TryGetValue(langCode, out var lData) || !lData.Entries.TryGetValue(key, out var entry)) return "";
            return entry.String;
        }

        public static void Reload(this LocalizationDropdownService ldService, LocalizationService lService)
        {
            var id = 0;
            var selectedId = 0;
            
            ldService.IdLangCodeMapper.Clear();
            ldService.OptionDataList.Clear();
            
            foreach (var langCode in lService.LangData.Keys)
            {
                if (langCode == lService.CurrLang.LanguageCode) selectedId = id;
                
                ldService.IdLangCodeMapper[id++] = langCode;
                
                ldService.OptionDataList.Add(new TMP_Dropdown.OptionData
                {
                    text = lService.GetString(langCode, LocalizationEntriesContracts.LanguageNameS),
                });
            }
            
            ldService.CurrentId = selectedId;
        }

        public static void UpdateDropdown(this LocalizationDropdownService ldService, TMP_Dropdown dropdown)
        {
            dropdown.options = ldService.OptionDataList;
            dropdown.SetValueWithoutNotify(ldService.CurrentId);
            dropdown.RefreshShownValue();
        }
    }
}