using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class LocalizationServiceExtensions
    {
        public static string GetString(this LocalizationService service, string key)
        {
            if (service.CurrLang == null || !service.CurrLang.Entries.TryGetValue(key, out var entry)) return "";
            return entry.String;
        }
    }
}