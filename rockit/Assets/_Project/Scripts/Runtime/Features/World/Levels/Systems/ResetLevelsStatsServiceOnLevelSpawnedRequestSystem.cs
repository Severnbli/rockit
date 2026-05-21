using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class ResetLevelsStatsServiceOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsStatsService _lsService;

        public ResetLevelsStatsServiceOnLevelSpawnedRequestSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            if (_lrAspect.LevelSpawnedRequests.IsEmptySlow()) return;
            
            _lsService.Reset();
        }
    }
}