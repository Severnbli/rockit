using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Scenes.Game;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class PersistLevelsStatsServiceStarsScoreOnLevelCompletedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsStatsService _lsService;
        private readonly LevelsService _lService;
        private readonly DataProvider _dProvider;

        public PersistLevelsStatsServiceStarsScoreOnLevelCompletedRequestSystem(LevelsStatsService lsService, 
            LevelsService lService, DataProvider dProvider)
        {
            _lsService = lsService;
            _lService = lService;
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;

            var levelId = _lService.CurrLevelId;
            var starsScore = _lsService.StarsScore;
            var gsData = _dProvider.GameSceneData;

            if (!gsData.CompletedLevels.TryGetValue(levelId, out var lData))
            {
                gsData.CompletedLevels.Add(levelId, new LevelData { Stars = starsScore });
            }
            else
            {
                lData.Stars = starsScore > lData.Stars ? starsScore : lData.Stars;
            }
            
            _dProvider.SaveTracked();
        }
    }
}