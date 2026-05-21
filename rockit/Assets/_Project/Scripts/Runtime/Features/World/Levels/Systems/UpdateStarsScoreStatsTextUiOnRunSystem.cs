using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdateStarsScoreStatsTextUiOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly LevelsAspect _lAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        private readonly LevelsStatsService _lsService;

        public UpdateStarsScoreStatsTextUiOnRunSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            foreach (var e in _lAspect.StarsScoreStatsTextUis)
            {
                ref var tuComponent = ref _tsAspect.TextUiComponentPool.Get(e);
                tuComponent.Text.text = _lsService.StarsScore.ToString();
            }
        }
    }
}