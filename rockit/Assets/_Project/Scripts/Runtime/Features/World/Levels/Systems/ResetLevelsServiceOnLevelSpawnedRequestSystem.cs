using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class ResetLevelsServiceOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsService _lService;

        public ResetLevelsServiceOnLevelSpawnedRequestSystem(LevelsService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            if (_lrAspect.LevelSpawnedRequests.IsEmptySlow()) return;
            _lService.Reset();
        }
    }
}