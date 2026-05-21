using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;
using _Project.Scripts.Runtime.Features.Stats.Constants;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class CacheCollectedConstantsOnConstantCollectedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly ConstantsRequestsAspect _crAspect;
        private readonly LevelsStatsService _lsService;

        public CacheCollectedConstantsOnConstantCollectedRequestSystem(LevelsStatsService lsService)
        {
            _lsService = lsService;
        }

        public void Run()
        {
            foreach (var e in _crAspect.ConstantCollectedRequests)
            {
                ref var ccRequest = ref _crAspect.ConstantCollectedRequestPool.Get(e);
                _lsService.CachedInvestigatedConstants.TryAdd(ccRequest.ConstantId, new ConstantData());
            }
        }
    }
}