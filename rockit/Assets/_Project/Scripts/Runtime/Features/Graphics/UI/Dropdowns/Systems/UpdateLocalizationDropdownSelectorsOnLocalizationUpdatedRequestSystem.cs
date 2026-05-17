using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Systems
{
    public sealed class UpdateLocalizationDropdownSelectorsOnLocalizationUpdatedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        [DI] private readonly DropdownsAspect _dAspect;
        private readonly LocalizationDropdownService _ldService;

        public UpdateLocalizationDropdownSelectorsOnLocalizationUpdatedRequestSystem(LocalizationDropdownService ldService)
        {
            _ldService = ldService;
        }

        public void Run()
        {
            if (_lrAspect.LocalizationUpdatedRequests.IsEmptySlow()) return;

            foreach (var e in _dAspect.DropdownLocalizationSelectors)
            {
                ref var dComponent = ref _dAspect.DropdownComponentPool.Get(e);
                _ldService.UpdateDropdown(dComponent.Dropdown);
            }
        }
    }
}