using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class SendConstantDisplayWindowRequestsByConstantsDisplaysServiceSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly ConstantsDisplaysService _cdService;

        public SendConstantDisplayWindowRequestsByConstantsDisplaysServiceSystem(ConstantsDisplaysService cdService)
        {
            _cdService = cdService;
        }

        public void Run()
        {
            if (_cdService.NearestConstantId == _cdService.LastNearestConstantId) return;
            if (_cdService.NearestConstantId == ProjectContracts.NullIntId)
            {
                ConstantsUtils.CreateHideConstantDisplayWindowRequest(_rAspect);
                return;
            }

            if (_cdService.LastNearestConstantId == ProjectContracts.NullIntId)
            {
                ConstantsUtils.CreateShowConstantDisplayWindowRequest(_rAspect);
            }

            var prepared = new RebuildConstantDisplayWindowRequest
            {
                ConstantId = _cdService.NearestConstantId
            };
            ConstantsUtils.CreateRebuildConstantDisplayWindowRequest(_rAspect, prepared);
        }
    }
}