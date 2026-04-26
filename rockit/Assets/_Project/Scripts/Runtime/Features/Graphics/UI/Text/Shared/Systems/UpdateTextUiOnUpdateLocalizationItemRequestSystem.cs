using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared.Systems
{
    public sealed class UpdateTextUiOnUpdateLocalizationItemRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly LocalizationAspect _lAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        private readonly LocalizationService _lService;
        private ProtoWorld _world;

        public UpdateTextUiOnUpdateLocalizationItemRequestSystem(LocalizationService lService)
        {
            _lService = lService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _lrAspect.UpdateLocalizationItemRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_tsAspect.LocalizationItemTextUis.Has(tarE)) continue;

                ref var liComponent = ref _lAspect.LocalizationItemComponentPool.Get(tarE);
                ref var tuComponent = ref _tsAspect.TextUiComponentPool.Get(tarE);

                tuComponent.Text.text = _lService.GetString(liComponent.Key);
            }
        }
    }
}