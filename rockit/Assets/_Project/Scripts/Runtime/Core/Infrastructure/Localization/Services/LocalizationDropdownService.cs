using System.Collections.Generic;
using TMPro;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services
{
    public sealed class LocalizationDropdownService
    {
        public List<TMP_Dropdown.OptionData> OptionDataList = new ();
        public SortedDictionary<int, string> IdLangCodeMapper = new ();
        public int CurrentId;
    }
}