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
            foreach (var e in _pmAspect.PlatformScaleChangeCreatables)
            {
                ref var pcbComponent = ref _pmAspect.PlatformChangesBufferComponentPool.Get(e);
                if (pcbComponent.PositionUpdates <= 0) continue;
                
                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(e);
                var target = pComponent.CurrScaleState == null 
                    ? pComponent.StartScaleState
                    : pComponent.CurrScaleState.Next;
                
                if (target == null)
                {
                    pcbComponent.ScaleUpdates = 0;
                    continue;
                }
                pcbComponent.ScaleUpdates--;
                
                pComponent.CurrScaleState = target;

                ref var pscComponent = ref _pmAspect.PlatformScaleChangeComponentPool.Add(e);
                pscComponent.Target = target.Value;
            }
        }
    }
}