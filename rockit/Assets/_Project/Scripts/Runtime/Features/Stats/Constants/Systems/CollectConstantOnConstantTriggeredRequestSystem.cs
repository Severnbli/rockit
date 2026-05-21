using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;
using _Project.Scripts.Runtime.Features.Stats.Constants.Requests;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Shared.Utils.Features.Stats;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class CollectConstantOnConstantTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly LevelsStatsService _lsService;

        public CollectConstantOnConstantTriggeredRequestSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            foreach (var reqE in _crAspect.ConstantTriggeredRequests)
            {
                ref var ctRequest = ref _crAspect.ConstantTriggeredRequestPool.Get(reqE);

                _lsService.CachedInvestigatedConstants.TryAdd(ctRequest.ConstantId, new ConstantData());
                
                CreateConstantCollectedRequest(reqE, ctRequest);
            }
        }

        private void CreateConstantCollectedRequest(ProtoEntity reqE, ConstantTriggeredRequest ctRequest)
        {
            ref var rComponent = ref _rAspect.CoreRequestsAspect.RequestComponentPool.Get(reqE);
            var prepared = new ConstantCollectedRequest
            {
                ConstantId = ctRequest.ConstantId
            };

            ConstantsUtils.CreateConstantCollectedRequests(_rAspect, rComponent.Entity, prepared);
        }
    }
}