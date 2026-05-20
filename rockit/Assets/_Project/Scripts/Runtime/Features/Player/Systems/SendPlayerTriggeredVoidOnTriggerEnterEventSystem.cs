using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Player.Systems
{
    public sealed class SendPlayerTriggeredVoidOnTriggerEnterEventSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect; 
        [DI] private readonly PlayerAspect _pAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        private readonly SharedIndexService _siService;
        private readonly LayersConfig _lConfig;
        private ProtoWorld _world;
        
        public SendPlayerTriggeredVoidOnTriggerEnterEventSystem(SharedIndexService siService, LayersConfig lConfig)
        {
            _siService = siService;
            _lConfig = lConfig;
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
                if (!_pAspect.Players.Has(tarE) || data.Collider.gameObject.layer != _lConfig.VoidLayer) continue;

                PlayerUtils.CreatePlayerTriggeredVoidRequest(_rAspect);
            }
        }
    }
}