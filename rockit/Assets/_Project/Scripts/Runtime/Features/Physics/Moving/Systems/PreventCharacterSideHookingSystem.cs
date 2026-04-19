using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class PreventCharacterSideHookingSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private readonly SharedIndexService _siService;
        private readonly SharedMovingConfig _smConfig;
        private ProtoWorld _world;

        public PreventCharacterSideHookingSystem(SharedIndexService siService, SharedMovingConfig smConfig)
        {
            _siService = siService;
            _smConfig = smConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            var goIndex = _siService.GameObjectIndex;
            
            foreach (var e in _psAspect.CollisionStayEvents)
            {
                ref var data = ref _psAspect.CollisionStayEventPool.Get(e);
                
                if (!goIndex.TryGetEntityFromIndex(data.Sender, _world, out var tarE)) continue;

                if (!_psAspect.Rigidbody2DCharacters.Has(tarE)) continue;
                
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
                
                rComponent.Rigidbody2D.ResetVelocityXOnSideCollision(data.Normal, _smConfig.SideCollisionTolerance);
            }
        }
    }
}