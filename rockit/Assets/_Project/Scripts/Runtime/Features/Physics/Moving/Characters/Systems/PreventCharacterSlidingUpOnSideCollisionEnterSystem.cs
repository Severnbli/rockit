using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class PreventCharacterSlidingUpOnSideCollisionEnterSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        private readonly SharedCharacterMovingConfig _smConfig;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public PreventCharacterSlidingUpOnSideCollisionEnterSystem(SharedCharacterMovingConfig smConfig, SharedIndexService siService)
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

                if (!_cmAspect.CharacterVelocityComponentPool.Has(tarE)) continue;
                
                if (Mathf.Abs(data.Normal.x) < _smConfig.CollisionTolerance) return;
                
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(tarE);
                cvComponent.Velocity.y = Mathf.Min(PhysicsSharedContracts.ForceNotApplied, cvComponent.Velocity.y);
            }
        }
    }
}