using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types
{
    [Serializable]
    public sealed class LanguageData
    {
        public string LanguageCode = "en";
        public Dictionary<string, LocalizationEntry> Entries = new();
    }
}