using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class RecalculateLevelsStatsOnRecalculateLevelsStatsRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        private readonly LevelsStatsService _lsService;
        private readonly LevelsService _lService;
        private readonly LevelsConfig _lConfig;

        public RecalculateLevelsStatsOnRecalculateLevelsStatsRequestSystem(LevelsStatsService lsService,
            LevelsService lService, LevelsConfig lConfig)
        {
            _lsService = lsService;
            _lService = lService;
            _lConfig = lConfig;
        }

        public void Run()
        {
            if (_lrAspect.RecalculateLevelsStatsRequests.IsEmptySlow()) return;

            var starsStages = _lService.CurrLevelDefinition.StarsStages;
            var usedTransforms = _lsService.UsedTransforms;
                
            var starsScore = _lConfig.MaxStarsPerLevel;
            var remainTransforms = LevelsContracts.DefaultTransformsCount;

            for (var i = 0; i < starsStages.Length; i++)
            {
                if (starsStages[i] >= usedTransforms)
                {
                    remainTransforms = starsStages[i] - usedTransforms;
                    break;
                }

                if (i != starsStages.Length - 1)
                {
                    starsScore--;
                    break;
                }

                starsScore = LevelsContracts.MinStarsQuantity;
            }
            
            _lsService.StarsScore = starsScore;
            _lsService.RemainTransforms = remainTransforms;
        }
    }
}