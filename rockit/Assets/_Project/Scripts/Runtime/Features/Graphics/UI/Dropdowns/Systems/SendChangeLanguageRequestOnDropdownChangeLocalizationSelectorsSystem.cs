using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Systems
{
    public sealed class SendChangeLanguageRequestOnDropdownChangeLocalizationSelectorsSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly DropdownsAspect _dAspect;
        [DI] private readonly UISharedAspect _usAspect;

        private readonly LocalizationService _lService;

        public SendChangeLanguageRequestOnDropdownChangeLocalizationSelectorsSystem(LocalizationService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            var (e, ok) = _dAspect.DropdownChangeLocalizationSelectors.FirstSlow();
            if (!ok) return;
            
            ref var dcComponent = ref _usAspect.DropdownChangeComponentPool.Get(e);

            if (!_lService.IdLanguageCodeMapper.TryGetValue(dcComponent.Value, out var langCode)) return;

            var prepared = new ChangeLanguageRequest
            {
                LanguageCode = langCode
            };
            LocalizationUtils.CreateChangeLanguageRequest(_rAspect, prepared);
        }
    }
}