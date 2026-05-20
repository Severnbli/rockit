using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdateLevelsStatsServiceUsedTransformsOnAnyPlatformsTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        private readonly LevelsService _lService;
        private readonly LevelsStatsService _lsService;

        public UpdateLevelsStatsServiceUsedTransformsOnAnyPlatformsTriggeredRequestSystem(LevelsService lService,
            LevelsStatsService lsService)
        {
            _lService = lService;
            _lsService = lsService;
        }

        public void Run()
        {
            if (_psrAspect.AnyPlatformTriggeredRequests.IsEmptySlow()) return;

            var useRate = _lService.CurrLevelDefinition?.TransformsUseRate ?? LevelsContracts.DefaultTransformsUseRate;
            var quantity = _psrAspect.AnyPlatformTriggeredRequests.LenSlow();
            
            _lsService.UsedTransforms += quantity * useRate;
        }
    }
}