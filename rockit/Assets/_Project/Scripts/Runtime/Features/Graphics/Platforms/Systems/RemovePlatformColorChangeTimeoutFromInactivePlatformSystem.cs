using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public sealed class RemovePlatformColorChangeTimeoutFromInactivePlatformSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        
        public void Run()
        {
            foreach (var e in _pgAspect.InactivePlatformsColorChangeTimeouts)
            {
                _pgAspect.PlatformColorChangeTimeoutComponentPool.Del(e);
            }
        }
    }
}