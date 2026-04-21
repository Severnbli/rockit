using _Project.Scripts.Runtime.Features.Platforms.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Systems
{
    public sealed class SpecifyPositionChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsMovingAspect _pmAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;

        public void Run()
        {
            foreach (var e in _pmAspect.PositionChangeCreatables)
            {
                ref var cbComponent = ref _pmAspect.ChangesBufferComponentPool.Get(e);
                if (cbComponent.PositionUpdates <= 0) continue;
                
                ref var pComponent = ref _psAspect.PlatformComponentPool.Get(e);
                var target = pComponent.CurrPosState == null 
                        ? pComponent.StartPosState
                        : pComponent.CurrPosState.Next;
                
                if (target == null)
                {
                    cbComponent.PositionUpdates = 0;
                    continue;
                }
                cbComponent.PositionUpdates--;
                
                pComponent.CurrPosState = target;

                ref var pcComponent = ref _pmAspect.PositionChangeComponentPool.Add(e);
                pcComponent.Target = target.Value;
            }
        }
    }
}