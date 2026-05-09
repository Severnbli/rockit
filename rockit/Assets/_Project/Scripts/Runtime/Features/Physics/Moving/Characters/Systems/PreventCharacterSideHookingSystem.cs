using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class PreventCharacterSideHookingSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsEventsAspect _peAspect;
        private readonly SharedIndexService _siService;
        private readonly SharedCharacterMovingConfig _smConfig;
        private ProtoWorld _world;

        public PreventCharacterSideHookingSystem(SharedIndexService siService, SharedCharacterMovingConfig smConfig)
        {
            _siService = siService;
            _smConfig = smConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void FixedRun()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var e in _peAspect.CollisionStayEvents)
            {
                ref var data = ref _peAspect.CollisionStayEventPool.Get(e);
                
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var tarE)) continue;

                if (!_cmAspect.CharacterVelocityComponentPool.Has(tarE)) continue;

                if (Mathf.Abs(data.Normal.x) < _smConfig.SideCollisionTolerance) return;
                
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(tarE);
                cvComponent.Velocity.x = Mathf.Approximately(Mathf.Sign(data.Normal.x), Mathf.Sign(cvComponent.Velocity.x)) 
                    ? cvComponent.Velocity.x 
                    : PhysicsSharedContracts.ForceNotApplied;
            }
        }
    }
}