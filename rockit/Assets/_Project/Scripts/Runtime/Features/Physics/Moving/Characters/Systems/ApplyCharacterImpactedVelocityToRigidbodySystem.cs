using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyCharacterImpactedVelocityToRigidbodySystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        
        public void FixedRun()
        {
            foreach (var e in _cmAspect.Rigidbody2DCharactersImpactedVelocities)
            {
                ref var civComponent = ref _cmAspect.CharacterImpactedVelocityComponentPool.Get(e);
                ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(e);
                rComponent.Rigidbody2D.linearVelocity = civComponent.Velocity;
            }
        }
    }
}