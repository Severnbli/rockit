using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdateLevelsServiceUsedTransformsOnAnyPlatformsTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        private readonly LevelsService _lService;

        public UpdateLevelsServiceUsedTransformsOnAnyPlatformsTriggeredRequestSystem(LevelsService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            if (_psrAspect.AnyPlatformTriggeredRequests.IsEmptySlow()) return;

            var useRate = _lService.CurrLevelDefinition?.TransformsUseRate ?? LevelsContracts.DefaultTransformsUseRate;
            var quantity = _psrAspect.AnyPlatformTriggeredRequests.LenSlow();
            
            _lService.UsedTransforms += quantity * useRate;
        }
    }
}