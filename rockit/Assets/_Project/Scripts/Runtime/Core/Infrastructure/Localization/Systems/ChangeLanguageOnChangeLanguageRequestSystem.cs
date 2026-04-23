using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Systems
{
    public sealed class ChangeLanguageOnChangeLanguageRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly LocalizationAspect _lAspect;
        private readonly LocalizationService _lService;
        private readonly DataProvider _dProvider;
        private ProtoWorld _world;

        public ChangeLanguageOnChangeLanguageRequestSystem(LocalizationService lService, DataProvider dProvider)
        {
            _lService = lService;
            _dProvider = dProvider;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.ChangeLanguageRequests.FirstSlow();
            if (!ok) return;

            var clRequest = _lrAspect.ChangeLanguageRequestPool.Get(e);
                
            if (!_lService.LangData.TryGetByKeyOrFirst(clRequest.LanguageCode, out _lService.CurrLang))
            {
                _lService.CurrLang = new LanguageData();
            }
            _dProvider.Language.Code = _lService.CurrLang.LanguageCode;

            foreach (var liEntity in _lAspect.LocalizationItems)
            {
                var packed = _world.PackEntityWithWorld(liEntity);
                LocalizationUtils.CreateUpdateLocalizationItemRequest(_rAspect, packed);
            }
        }
    }
}