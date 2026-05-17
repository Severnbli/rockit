using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;

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
    }
}