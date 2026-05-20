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

        public UpdatePlatformsInputServiceProfileOnLevelSpawnedRequestSystem(PlatformsInputService piService)
        {
            _piService = piService;
        }

        public void Run()
        {
            var (e, ok) = _lrAspect.LevelSpawnedRequests.FirstSlow();
            if (!ok) return;

            ref var lsRequest = ref _lrAspect.LevelSpawnedRequestPool.Get(e);
            _piService.SetProfile(lsRequest.Definition.PiProfile);
        }
    }
}