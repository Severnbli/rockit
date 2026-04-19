using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class CharactersVelocityResetOnSideCollisionEnterSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private readonly SharedMovingConfig _smConfig;
        private readonly SharedIndexService _siService;
        private ProtoWorld _world;

        public CharactersVelocityResetOnSideCollisionEnterSystem(SharedMovingConfig smConfig, SharedIndexService siService)
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
            
            foreach (var e in _psAspect.CollisionEnterEvents)
            {
                ref var data = ref _psAspect.CollisionEnterEventPool.Get(e);
                
                if (!goIndex.TryGetValue(data.Sender, out var packed) ||
                    !packed.TryUnpackCompletely(_world, out var tarE)) continue;

                if (!_psAspect.Rigidbody2DCharacters.Has(tarE)) continue;
                
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
                
                rComponent.Rigidbody2D.ResetVelocityYOnSideCollision(data.Normal, _smConfig.SideCollisionTolerance);
            }
        }
    }
}