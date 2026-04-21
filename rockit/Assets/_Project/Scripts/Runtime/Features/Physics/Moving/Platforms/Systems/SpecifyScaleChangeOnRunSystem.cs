using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SpecifyScaleChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;

        public void Run()
        {
            foreach (var e in _pmAspect.ScaleChangeCreatables)
            {
                ref var cbComponent = ref _pmAspect.ChangesBufferComponentPool.Get(e);
                if (cbComponent.PositionUpdates <= 0) continue;
                
                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(e);
                var target = pComponent.CurrScaleState == null 
                    ? pComponent.StartScaleState
                    : pComponent.CurrScaleState.Next;
                
                if (target == null)
                {
                    cbComponent.ScaleUpdates = 0;
                    continue;
                }
                
                pComponent.CurrScaleState = target;

                ref var scComponent = ref _pmAspect.ScaleChangeComponentPool.Add(e);
                scComponent.Target = target.Value;
            }
        }
    }
}