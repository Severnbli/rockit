using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class LanguageData
    {
        public string Code = LocalizationContracts.DefaultLanguage;
    }
}