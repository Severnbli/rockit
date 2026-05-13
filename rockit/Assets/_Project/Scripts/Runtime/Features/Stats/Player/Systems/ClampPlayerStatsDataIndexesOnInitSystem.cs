using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class ClampPlayerStatsDataIndexesOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerStatsConfig _psConfig;
        private readonly DataProvider _dProvider;

        public ClampPlayerStatsDataIndexesOnInitSystem(DataProvider dProvider, PlayerStatsConfig psConfig)
        {
            _dProvider = dProvider;
            _psConfig = psConfig;
        }

        public void Init(IProtoSystems systems)
        {
            PlayerStatsUtils.ClampPlayerStatsDataIndexesToConfig(_dProvider.StatsData.PlayerStatsData, _psConfig);
        }
    }
}