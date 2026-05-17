using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class ChangeLanguageOnChangeLanguageRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly LocalizationAspect _lAspect;
        private readonly LocalizationService _lService;
        private readonly DataProvider _dProvider;

        public ChangeLanguageOnChangeLanguageRequestSystem(LocalizationService lService, DataProvider dProvider)
        {
            _lService = lService;
            _dProvider = dProvider;
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.ChangeLanguageRequests.FirstSlow();
            if (!ok) return;

            var clRequest = _lrAspect.ChangeLanguageRequestPool.Get(e);
            _lService.UpdateByLanguageCode(clRequest.LanguageCode);
            _dProvider.LanguageData.Code = _lService.CurrLang.LanguageCode;
            _dProvider.SaveTracked();

            LocalizationUtils.CreateLocalizationUpdatedRequest(_rAspect);
        }
    }
}