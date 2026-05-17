using _Project.Scripts.Runtime.Features.Graphics.UI.Text.Shared;
using _Project.Scripts.Runtime.Features.Stats.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Shared.Systems
{
    public sealed class UpdateStarsTotalizersTextUisOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly StatsSharedAspect _ssAspect;
        [DI] private readonly TextSharedAspect _tsAspect;
        private readonly GameStatsService _gsService;

        public UpdateStarsTotalizersTextUisOnRunSystem(GameStatsService gsService)
        {
            _gsService = gsService;
        }

        public void Run()
        {
            foreach (var e in _ssAspect.StarsTotalizerTextUis)
            {
                ref var tuComponent = ref _tsAspect.TextUiComponentPool.Get(e);
                tuComponent.Text.text = _gsService.TotalStars.ToString();
            }
        }
    }
}