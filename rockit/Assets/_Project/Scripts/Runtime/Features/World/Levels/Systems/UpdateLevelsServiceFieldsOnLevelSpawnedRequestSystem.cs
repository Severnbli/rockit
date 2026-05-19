using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdateLevelsServiceFieldsOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsService _lService;

        public UpdateLevelsServiceFieldsOnLevelSpawnedRequestSystem(LevelsService lService)
        {
            _lService = lService;
        }

        public void Run()
        {
            var (e, ok) = ref _lrAspect.LevelSpawnedRequests.FirstSlow();
            if (!ok) return;

            ref var lsRequest = ref _lrAspect.LevelSpawnedRequestPool.Get(e);
            _lService.CurrLevelId = lsRequest.LevelId;
            _lService.CurrLevel = lsRequest.Level;
        }
    }
}