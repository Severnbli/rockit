using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player.Systems
{
    public sealed class SendDisablePlayerRequestOnLevelCompletedRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly LevelsRequestsAspect _lrAspect;
        [DI] private readonly PlayerAspect _pAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            if (_lrAspect.LevelCompletedRequests.IsEmptySlow()) return;

            foreach (var e in _pAspect.Players)
            {
                var packed = _world.PackEntityWithWorld(e);
                SharedUtils.CreateDisableRequest(_rAspect, packed);
            }
        }
    }
}