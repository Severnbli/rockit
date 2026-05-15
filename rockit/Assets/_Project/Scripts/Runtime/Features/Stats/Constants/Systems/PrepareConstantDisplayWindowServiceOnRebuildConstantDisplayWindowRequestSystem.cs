using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Stats.Constants.Configs;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Features.Stats.Player.Configs;
using _Project.Scripts.Runtime.Features.Stats.Player.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class PrepareConstantDisplayWindowServiceOnRebuildConstantDisplayWindowRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly ConstantDisplayWindowService _cdwService;
        private readonly ConstantsConfig _cConfig;
        private readonly PlayerStatsService _psService;
        private readonly PlayerStatsConfig _psConfig;

        public PrepareConstantDisplayWindowServiceOnRebuildConstantDisplayWindowRequestSystem(
            ConstantDisplayWindowService cdwService, ConstantsConfig cConfig, PlayerStatsService psService,
            PlayerStatsConfig psConfig)
        {
            _cdwService = cdwService;
            _cConfig = cConfig;
            _psService = psService;
            _psConfig = psConfig;
        }

        public void Run()
        {
            var (e, ok) = _crAspect.RebuildConstantDisplayWindowRequests.FirstSlow();
            if (!ok) return;
            
            ref var rbdwRequest = ref _crAspect.RebuildConstantDisplayWindowRequestPool.Get(e);
            if (rbdwRequest.ConstantId == _cdwService.LastPreparedConstantId) return;
            
            _cdwService.Prepared = false;

            if (!_cConfig.Constants.TryGetValue(rbdwRequest.ConstantId, out var def)) return;
            if (!PlayerStatsUtils.TryGetArrayByConstantDefinition(def, _psConfig, out var array)) return;
            if (!PlayerStatsUtils.TryGetObserverByConstantDefinition(def, _psService, out var observer)) return;
            
            _cdwService.LastPreparedConstantId = rbdwRequest.ConstantId;
            _cdwService.Definition = def;
            _cdwService.Array = array;
            _cdwService.Observer = observer;
            _cdwService.Prepared = true;
        }
    }
}