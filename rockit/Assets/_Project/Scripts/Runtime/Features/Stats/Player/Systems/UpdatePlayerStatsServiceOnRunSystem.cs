using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class UpdatePlayerStatsServiceOnRunSystem : IProtoRunSystem
    {
        private readonly PlayerStatsService _psService;
        private readonly PlayerStats _pStats;
        private readonly PlayerStatsConfig _psConfig;

        public UpdatePlayerStatsServiceOnRunSystem(PlayerStatsService psService, DataProvider dProvider,
            PlayerStatsConfig psConfig)
        {
            _psService = psService;
            _pStats = dProvider.PlayerStats;
            _psConfig = psConfig;
        }

        public void Run()
        {
            _psService.UpdatePlayerStatsService(_pStats, _psConfig);
        }
    }
}