using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Features.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SendRecalculateLevelsStatsRequestOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        
        public void Run()
        {
            if (_lrAspect.LevelSpawnedRequests.IsEmptySlow()) return;
            
            LevelsUtils.CreateRecalculateLevelsStatsRequest(_rAspect);
        }
    }
}