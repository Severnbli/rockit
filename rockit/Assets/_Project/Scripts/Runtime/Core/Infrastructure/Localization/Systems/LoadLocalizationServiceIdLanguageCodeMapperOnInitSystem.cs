using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class LoadLocalizationServiceIdLanguageCodeMapperOnInitSystem : IProtoInitSystem
    {
        private readonly LocalizationService _lService;

        public LoadLocalizationServiceIdLanguageCodeMapperOnInitSystem(LocalizationService lService)
        {
            _lService = lService;
        }

        public void Init(IProtoSystems systems)
        {
            var i = 0;
            foreach (var langCode in _lService.LangData.Keys)
            {
                _lService.IdLanguageCodeMapper[i++] = langCode;
            }
        }
    }
}