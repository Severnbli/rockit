using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class RemoveMoveSnapByGroundCheckResultSystem : IProtoFixedRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly MovingSharedAspect _msAspect;
        
        public void FixedRun()
        {
            foreach (var e in _cmAspect.MoveSnapRemovables)
            {
                ref var gcrComponent = ref _cmAspect.GroundCheckResultComponentPool.Get(e);
                if (gcrComponent.Grounded) continue;
                
                _msAspect.MoveSnapComponentPool.Del(e);
            }
        }
    }
}