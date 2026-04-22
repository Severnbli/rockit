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
                
                ref var psComponent = ref _psAspect.PlatformStatesComponentPool.Get(e);
                var target = psComponent.CurrRotState == null 
                    ? psComponent.StartRotState
                    : psComponent.CurrRotState.Next;
                
                if (target == null)
                {
                    pcbComponent.RotationUpdates = 0;
                    continue;
                }
                pcbComponent.RotationUpdates--;
                
                psComponent.CurrRotState = target;

                ref var prcComponent = ref _pmAspect.PlatformRotationChangeComponentPool.Add(e);
                prcComponent.Target = target.Value;
            }
        }
    }
}