using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SpecifyRotationChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;

        public void Run()
        {
            foreach (var e in _pmAspect.RotationChangeCreatables)
            {
                ref var cbComponent = ref _pmAspect.ChangesBufferComponentPool.Get(e);
                if (cbComponent.PositionUpdates <= 0) continue;
                
                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(e);
                var target = pComponent.CurrRotState == null 
                    ? pComponent.StartRotState
                    : pComponent.CurrRotState.Next;
                
                if (target == null)
                {
                    cbComponent.RotationUpdates = 0;
                    continue;
                }
                cbComponent.RotationUpdates--;
                
                pComponent.CurrRotState = target;

                ref var rcComponent = ref _pmAspect.RotationChangeComponentPool.Add(e);
                rcComponent.Target = target.Value;
            }
        }
    }
}