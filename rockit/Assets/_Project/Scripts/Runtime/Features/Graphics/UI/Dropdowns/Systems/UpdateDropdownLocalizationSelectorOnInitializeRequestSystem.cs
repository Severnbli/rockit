using _Project.Scripts.Runtime.Core.Infrastructure.Localization.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Systems
{
    public sealed class UpdateDropdownLocalizationSelectorOnInitializeRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DIRequests] private readonly SharedRequestsAspect _srAspect;
        [DI] private readonly DropdownsAspect _dAspect;
        private readonly LocalizationDropdownService _ldService;
        private ProtoWorld _world;

        public UpdateDropdownLocalizationSelectorOnInitializeRequestSystem(LocalizationDropdownService ldService)
        {
            _ldService = ldService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _srAspect.InitializeRunRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_dAspect.DropdownLocalizationSelectors.Has(tarE)) continue;
                
                ref var dComponent = ref _dAspect.DropdownComponentPool.Get(tarE);
                _ldService.UpdateDropdown(dComponent.Dropdown);
            }
        }
    }
}