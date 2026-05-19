using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Player.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.World.Levels.Systems
{
    public sealed class SendPlacePlayerRequestOnLevelSpawnedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        
        public void Run()
        {
            var (e, ok) = _lrAspect.LevelSpawnedRequests.FirstSlow();
            if (!ok) return;

            ref var lsRequest = ref _lrAspect.LevelSpawnedRequestPool.Get(e);
            var prepared = new PlacePlayerRequest
            {
                To = lsRequest.Level.PsPosition.transform.position
            };
            
            PlayerUtils.CreatePlacePlayerRequest(_rAspect, prepared);
        }
    }
}