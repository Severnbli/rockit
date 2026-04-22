using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class CreateMoveSnapByGroundCheckResultSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly MovingSharedAspect _msAspect;
        private readonly PhysicsService _service;

        public CreateMoveSnapByGroundCheckResultSystem(PhysicsService service)
        {
            _service = service;
        }

        public void FixedRun()
        {
            foreach (var e in _cmAspect.MoveSnapCreatables)
            {
                ref var result = ref _cmAspect.GroundCheckResultComponentPool.Get(e);

                if (!result.Grounded ||
                    !_service.PhysicsMatcher.TryGetByFirst(result.GroundCollider, out var groundRigidbody)) continue;
                
                ref var rigidbody = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                ref var msComponent = ref _msAspect.MoveSnapComponentPool.Add(e);

                msComponent.Host = groundRigidbody;
                msComponent.LastHostPos = groundRigidbody.position;
                msComponent.Tied = rigidbody.Rigidbody2D;
            }
        }
    }
}