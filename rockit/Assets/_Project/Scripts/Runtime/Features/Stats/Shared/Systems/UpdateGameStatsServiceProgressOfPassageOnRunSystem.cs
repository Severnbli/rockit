using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Shared.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Shared.Systems
{
    public sealed class UpdateGameStatsServiceProgressOfPassageOnRunSystem : IProtoRunSystem
    {
        private readonly GameStatsService _gsService;
        private readonly LevelsConfig _lConfig;
        private readonly DataProvider _dProvider;

        public UpdateGameStatsServiceProgressOfPassageOnRunSystem(GameStatsService gsService, LevelsConfig lConfig,
            DataProvider dProvider)
        {
            _gsService = gsService;
            _lConfig = lConfig;
            _dProvider = dProvider;
        }

        public void Run()
        {
            _gsService.ProgressOfPassage01 = GameStatsUtils.GetProgressOfPassage01(_dProvider, _lConfig);
            _gsService.ProgressOfPassage0100 = _gsService.ProgressOfPassage01 * 100f;
        }
    }
}