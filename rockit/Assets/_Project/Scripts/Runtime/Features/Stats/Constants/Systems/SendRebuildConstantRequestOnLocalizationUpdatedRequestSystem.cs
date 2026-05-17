using _Project.Scripts.Runtime.Core.Infrastructure.Localization;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class SendRebuildConstantRequestOnLocalizationUpdatedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LocalizationRequestsAspect _lrAspect;
        private readonly ConstantDisplayWindowService _cdwService;

        public SendRebuildConstantRequestOnLocalizationUpdatedRequestSystem(ConstantDisplayWindowService cdwService)
        {
            _cdwService = cdwService;
        }

        public void Run()
        {
            if (_lrAspect.LocalizationUpdatedRequests.IsEmptySlow()) return;

            var prepared = new RebuildConstantDisplayWindowRequest
            {
                ConstantId = _cdwService.LastPreparedConstantId
            };
            
            ConstantsUtils.CreateRebuildConstantDisplayWindowRequest(_rAspect, prepared);
        }
    }
}