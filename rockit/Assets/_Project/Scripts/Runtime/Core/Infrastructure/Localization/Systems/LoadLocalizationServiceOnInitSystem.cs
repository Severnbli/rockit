using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class LoadLocalizationServiceOnInitSystem : IProtoInitSystem
    {
        private readonly LocalizationService _lService;
        private readonly DataProvider _dProvider;

        public LoadLocalizationServiceOnInitSystem(LocalizationService lService, DataProvider dProvider)
        {
            _lService = lService;
            _dProvider = dProvider;
        }

        public void Init(IProtoSystems systems)
        {
            var lData = LocalizationUtils.GetLanguageDataDictionary();
            _lService.LangData = lData;

            if (lData.TryGetByKeyOrFirst(_dProvider.Language.Code, out _lService.CurrLang)) return;

            _lService.CurrLang = new LanguageData();
        }
    }
}