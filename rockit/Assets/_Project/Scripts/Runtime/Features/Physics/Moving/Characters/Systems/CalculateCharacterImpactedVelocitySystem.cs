using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class CalculateCharacterImpactedVelocitySystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly MovingSharedAspect _msAspect;
        
        public void FixedRun()
        {
            foreach (var e in _cmAspect.CharacterVelocities)
            {
                ref var civComponent = ref _cmAspect.CharacterImpactedVelocityComponentPool.GetOrAdd(e);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.Get(e);

                civComponent.Velocity = cvComponent.Velocity;
                
                if (_msAspect.MoveSnaps.Has(e))
                {
                    ref var msComponent = ref _msAspect.MoveSnapComponentPool.Get(e);
                    civComponent.Velocity += msComponent.HostVelocity;
                }
            }
        }
    }
}