using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class ClampPlayerStatsEntityIndexesOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerStats _pStats;
        private readonly PlayerStatsConfig _psConfig;

        public ClampPlayerStatsEntityIndexesOnInitSystem(DataProvider dProvider, PlayerStatsConfig psConfig)
        {
            _psConfig = psConfig;
            _pStats = dProvider.PlayerStats;
        }

        public void Init(IProtoSystems systems)
        {
            _pStats.ClampPlayerStatsEntityIndexes(_psConfig);
        }
    }
}