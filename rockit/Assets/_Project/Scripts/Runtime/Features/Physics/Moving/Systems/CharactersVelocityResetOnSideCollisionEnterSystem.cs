using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class CharactersVelocityResetOnSideCollisionEnterSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly SharedAspect _sAspect;
        private readonly PhysicsService _pService;

        public CharactersVelocityResetOnSideCollisionEnterSystem(PhysicsService pService)
        {
            _pService = pService;
        }
        
        public void Run()
        {
            foreach (var e in _psAspect.CollisionEnterEvents)
            {
                ref var data = ref _psAspect.CollisionEnterEventPool.Get(e);
                var matcher = _pService.GameObjectRigidbody2DMatcher;

                if (!matcher.TryGetByFirst(data.Sender, out var rigidbody) ||
                    !matcher.TryObtainByFirst(data.Sender, out var tarE)) continue;

                if (!_sAspect.Characters.Has(tarE)) continue;
                
                rigidbody.ResetVelocityOnSideCollision(data.Normal);
            }
        }
    }
}