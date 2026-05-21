using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class UpdateRemainTransformsStatsTextUiOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly LevelsAspect _lAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        private readonly LevelsStatsService _lsService;

        public UpdateRemainTransformsStatsTextUiOnRunSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            foreach (var e in _lAspect.RemainTransformsStatsTextUis)
            {
                ref var tuComponent = ref _tsAspect.TextUiComponentPool.Get(e);

                tuComponent.Text.text = _lsService.StarsScore > 0
                    ? _lsService.RemainTransforms.ToString()
                    : ProjectContracts.InfinitySymbol;
            }
        }
    }
}