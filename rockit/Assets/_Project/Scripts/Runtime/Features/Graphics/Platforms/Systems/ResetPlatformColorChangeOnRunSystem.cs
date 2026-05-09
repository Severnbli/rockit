using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public sealed class ResetPlatformColorChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        
        public void Run()
        {
            foreach (var e in _pgAspect.PlatformColorChangeResetables)
            {
                ref var pccComponent = ref _pgAspect.PlatformColorChangeComponentPool.Get(e);

                pccComponent.Blocked = false;
                pccComponent.PositionColorWas = false;
                pccComponent.RotationColorWas = false;
                pccComponent.ScaleColorWas = false;
            }
        }
    }
}