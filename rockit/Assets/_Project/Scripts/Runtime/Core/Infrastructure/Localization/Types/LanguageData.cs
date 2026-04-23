using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types
{
    [Serializable]
    public class LanguageData
    {
        public string LanguageCode = "en";
        public List<LocalizationEntry> Entries = new();
    }
}