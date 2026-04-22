using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SpecifyPlatformPositionChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;

        public void Run()
        {
            foreach (var e in _pmAspect.PlatformPositionChangeCreatables)
            {
                ref var pcbComponent = ref _pmAspect.PlatformChangesBufferComponentPool.Get(e);
                if (pcbComponent.PositionUpdates <= 0) continue;
                
                ref var psComponent = ref _psAspect.PlatformStatesComponentPool.Get(e);
                var target = psComponent.CurrPosState == null 
                        ? psComponent.StartPosState
                        : psComponent.CurrPosState.Next;
                
                if (target == null)
                {
                    pcbComponent.PositionUpdates = 0;
                    continue;
                }
                pcbComponent.PositionUpdates--;
                
                psComponent.CurrPosState = target;

                ref var ppcComponent = ref _pmAspect.PlatformPositionChangeComponentPool.Add(e);
                ppcComponent.Target = target.Value;
            }
        }
    }
}