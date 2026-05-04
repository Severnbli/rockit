using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class ClampPlayerStatsEntityIndexesOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerStatsConfig _psConfig;
        private readonly DataProvider _dProvider;

        public ClampPlayerStatsEntityIndexesOnInitSystem(DataProvider dProvider, PlayerStatsConfig psConfig)
        {
            _dProvider = dProvider;
            _psConfig = psConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _dProvider.PlayerStats.ClampPlayerStatsEntityIndexes(_psConfig);
        }
    }
}