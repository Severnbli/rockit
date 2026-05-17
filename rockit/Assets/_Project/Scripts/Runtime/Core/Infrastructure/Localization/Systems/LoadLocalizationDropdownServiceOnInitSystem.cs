using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class LoadLocalizationDropdownServiceOnInitSystem : IProtoInitSystem
    {
        private readonly LocalizationService _lService;
        private readonly LocalizationDropdownService _ldService;

        public LoadLocalizationDropdownServiceOnInitSystem(LocalizationService lService, 
            LocalizationDropdownService ldService)
        {
            _lService = lService;
            _ldService = ldService;
        }

        public void Init(IProtoSystems systems)
        {
            _ldService.Reload(_lService);
        }
    }
}