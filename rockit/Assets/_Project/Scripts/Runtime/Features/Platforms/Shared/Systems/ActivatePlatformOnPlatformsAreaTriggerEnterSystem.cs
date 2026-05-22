using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class ActivatePlatformOnPlatformsAreaTriggerEnterSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public ActivatePlatformOnPlatformsAreaTriggerEnterSystem(SharedIndexService siService)
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
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var firstE)) continue;
                if (!goIndex.TryGetEntityFromIndex(data.Collider.gameObject, _world, out var secondE)) continue;

                if (!_psAspect.InactivePlatforms.Has(firstE)) continue;
                if (!_psAspect.PlatformsAreas.Has(secondE)) continue;
                
                _psAspect.ActivePlatformTagPool.Add(firstE);
                
                var packed = _world.PackEntityWithWorld(firstE);
                PlatformsUtils.CreatePlatformActivatedRequest(_rAspect, packed);
            }
        }
    }
}