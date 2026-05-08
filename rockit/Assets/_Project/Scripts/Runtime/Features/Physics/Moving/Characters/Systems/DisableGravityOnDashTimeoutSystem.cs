using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Features.Physics.Shared.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class DisableGravityOnDashTimeoutSystem : IProtoRunSystem
    {
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly ForcesService _fService;

        public DisableGravityOnDashTimeoutSystem(ForcesService fService)
        {
            _fService = fService;
        }

        public void Run()
        {
            foreach (var e in _psAspect.Rigidbody2DCharacters)
            {
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                rComponent.Rigidbody2D.gravityScale = _cmAspect.DashTimeouts.Has(e)
                    ? PhysicsSharedContracts.ForceNotApplied
                    : _fService.GravityScale;
            }
        }
    }
}