using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Shared.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Shared.Systems
{
    public sealed class UpdateGameStatsServiceTotalStarsOnRunSystem : IProtoRunSystem
    {
        private readonly GameStatsService _gsService;
        private readonly DataProvider _dProvider;

        public UpdateGameStatsServiceTotalStarsOnRunSystem(GameStatsService gsService)
        {
            _gsService = gsService;
        }

        public void Run()
        {
            _gsService.TotalStars = GameStatsUtils.GetTotalStars(_dProvider);
        }
    }
}