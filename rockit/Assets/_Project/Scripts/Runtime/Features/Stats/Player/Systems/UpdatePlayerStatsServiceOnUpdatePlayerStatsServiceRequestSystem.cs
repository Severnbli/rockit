using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Player.Systems
{
    public sealed class UpdatePlayerStatsServiceOnUpdatePlayerStatsServiceRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlayerStatsRequestsAspect _psrAspect;
        private readonly PlayerStatsService _psService;
        private readonly PlayerStatsConfig _psConfig;
        private readonly DataProvider _dProvider;

        public UpdatePlayerStatsServiceOnUpdatePlayerStatsServiceRequestSystem(PlayerStatsService psService,
            PlayerStatsConfig psConfig, DataProvider dProvider)
        {
            _psService = psService;
            _psConfig = psConfig;
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_psrAspect.UpdatePlayerStatsRequests.IsEmptySlow()) return;
            
            _psService.UpdatePlayerStatsService(_dProvider.PlayerStats, _psConfig);
        }
    }
}