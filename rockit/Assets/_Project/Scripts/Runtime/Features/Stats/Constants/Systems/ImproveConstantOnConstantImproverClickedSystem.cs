using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class ImproveConstantOnConstantImproverClickedSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly ConstantsAspect _cAspect;
        private readonly ConstantDisplayWindowService _cdwService;

        public ImproveConstantOnConstantImproverClickedSystem(ConstantDisplayWindowService cdwService)
        {
            _cdwService = cdwService;
        }

        public void Run()
        {
            if (!_cdwService.Prepared || _cAspect.ClickedConstantsImprovers.IsEmptySlow()) return;
            _cdwService.Observer.GoToNext();

            var prepared = new RebuildConstantDisplayWindowRequest
            {
                ConstantId = _cdwService.LastPreparedConstantId
            };

            ConstantsUtils.CreateRebuildConstantDisplayWindowRequest(_rAspect, prepared);
            PlayerStatsUtils.CreateSyncPlayerStatsServiceToStorageRequest(_rAspect);
        }
    }
}