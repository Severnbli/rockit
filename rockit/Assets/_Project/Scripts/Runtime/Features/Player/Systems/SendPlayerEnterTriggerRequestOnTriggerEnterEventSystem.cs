using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Player.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player.Systems
{
    public sealed class SendPlayerEnterTriggerRequestOnTriggerEnterEventSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlayerRequestsAspect _prAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        [DI] private readonly PlayerAspect _pAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public SendPlayerEnterTriggerRequestOnTriggerEnterEventSystem(SharedIndexService siService)
        {
            _siService = siService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var evE in _peAspect.TriggerEnterEvents)
            {
                ref var data = ref _peAspect.TriggerEnterEventPool.Get(evE);
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var tarE)) continue;
                if (!_pAspect.Players.Has(tarE)) continue;

                var prepared = new PlayerEnterTriggerRequest
                {
                    Collider = data.Collider
                };
                PlayerUtils.CreatePlayerEnterTriggerRequest(_rAspect, prepared);
            }
        }
    }
}