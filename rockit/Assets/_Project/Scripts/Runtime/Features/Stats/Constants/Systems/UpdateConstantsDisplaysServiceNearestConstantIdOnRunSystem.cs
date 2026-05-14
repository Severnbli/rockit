using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Systems
{
    public sealed class UpdateConstantsDisplaysServiceNearestConstantIdOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly ConstantsAspect _cAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly ConstantsDisplaysService _cdService;

        public UpdateConstantsDisplaysServiceNearestConstantIdOnRunSystem(ConstantsDisplaysService cdService)
        {
            _cdService = cdService;
        }

        public void Run()
        {
            var minDistance = Mathf.Infinity;
            var constantId = ProjectContracts.NullIntId;
            
            foreach (var e in _cAspect.ConstantActiveDisplayConstantPlayerLocators)
            {
                ref var plComponent = ref _sAspect.PlayerLocatorComponentPool.Get(e);
                if (plComponent.Distance > minDistance) continue;
                
                minDistance = plComponent.Distance;
                ref var cComponent = ref _cAspect.ConstantComponentPool.Get(e);
                constantId = cComponent.Id;
            }
            
            _cdService.NearestConstantId = constantId;
        }
    }
}