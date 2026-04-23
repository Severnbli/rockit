using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class LoadLocalizationServiceOnInitSystem : IProtoInitSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
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

            var prepared = new ChangeLanguageRequest
            {
                LanguageCode = _dProvider.Language.Code
            };
            
            LocalizationUtils.CreateChangeLanguageRequest(_rAspect, prepared);
        }
    }
}