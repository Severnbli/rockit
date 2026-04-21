using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SpecifyPlatformRotationChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;

        public void Run()
        {
            foreach (var e in _pmAspect.PlatformRotationChangeCreatables)
            {
                ref var pcbComponent = ref _pmAspect.PlatformChangesBufferComponentPool.Get(e);
                if (pcbComponent.PositionUpdates <= 0) continue;
                
                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(e);
                var target = pComponent.CurrRotState == null 
                    ? pComponent.StartRotState
                    : pComponent.CurrRotState.Next;
                
                if (target == null)
                {
                    pcbComponent.RotationUpdates = 0;
                    continue;
                }
                pcbComponent.RotationUpdates--;
                
                pComponent.CurrRotState = target;

                ref var prcComponent = ref _pmAspect.PlatformRotationChangeComponentPool.Add(e);
                prcComponent.Target = target.Value;
            }
        }
    }
}