using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services
{
    public sealed class LocalizationService
    {
        public Dictionary<string, LanguageData> LangData;
        public LanguageData CurrLang;
    }
}