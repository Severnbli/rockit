using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class PreventCharactersSlidingUpOnSideCollisionEnterSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        private readonly SharedCharacterMovingConfig _smConfig;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public PreventCharactersSlidingUpOnSideCollisionEnterSystem(SharedCharacterMovingConfig smConfig, SharedIndexService siService)
        {
            _smConfig = smConfig;
            _siService = siService;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }
        
        public void Run()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var e in _peAspect.CollisionEnterEvents)
            {
                ref var data = ref _peAspect.CollisionEnterEventPool.Get(e);
                
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var tarE)) continue;

                if (!_psAspect.Rigidbody2DCharacters.Has(tarE)) continue;
                
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
                
                rComponent.Rigidbody2D.ResetPositiveVelocityYOnSideCollision(data.Normal, _smConfig.SideCollisionTolerance);
            }
        }
    }
}