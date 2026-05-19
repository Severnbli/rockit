using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player.Systems
{
    public sealed class PlacePlayerOnPlacePlayerRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly PlayerAspect _pAspect;
        [DI] private readonly SharedAspect _sAspect;
        
        public void Run()
        {
            var (reqE, ok) = _prAspect.PlacePlayerRequests.FirstSlow();
            if (!ok) return;

            ref var ppRequest = ref _prAspect.PlacePlayerRequestPool.Get(reqE);

            foreach (var e in _pAspect.TransformPlayers)
            {
                ref var tComponent = ref _sAspect.TransformComponentPool.Get(e);
                tComponent.Transform.PlaceTo(ppRequest.To);
            }
        }
    }
}