using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdatePlatformsInputServiceProfileOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly PlatformsInputService _piService;
        private readonly LevelsConfig _lConfig;

        public UpdatePlatformsInputServiceProfileOnLevelSpawnedRequestSystem(PlatformsInputService piService, LevelsConfig lConfig)
        {
            _piService = piService;
            _lConfig = lConfig;
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.LevelSpawnedRequests.FirstSlow();
            if (!ok) return;

            ref var lsRequest = ref _lrAspect.LevelSpawnedRequestPool.Get(e);
            if (!_lConfig.Levels.TryGetValue(lsRequest.LevelId, out var lDefinition)) return;
            
            _piService.SetProfile(lDefinition.PiProfile);
        }
    }
}