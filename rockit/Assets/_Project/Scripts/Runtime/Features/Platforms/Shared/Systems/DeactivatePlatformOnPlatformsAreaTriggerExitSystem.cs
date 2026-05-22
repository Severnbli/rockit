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
    public sealed class DeactivatePlatformOnPlatformsAreaTriggerExitSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public DeactivatePlatformOnPlatformsAreaTriggerExitSystem(SharedIndexService siService)
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
            
            foreach (var evE in _peAspect.TriggerExitEvents)
            {
                ref var data = ref _peAspect.TriggerExitEventPool.Get(evE);
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var firstE)) continue;
                if (!goIndex.TryGetEntityFromIndex(data.Collider.gameObject, _world, out var secondE)) continue;

                if (!_psAspect.ActivePlatforms.Has(firstE)) continue;
                if (!_psAspect.PlatformsAreas.Has(secondE)) continue;
                
                _psAspect.ActivePlatformTagPool.Del(firstE);
                
                var packed = _world.PackEntityWithWorld(firstE);
                PlatformsUtils.CreatePlatformDeactivatedRequest(_rAspect, packed);
            }
        }
    }
}