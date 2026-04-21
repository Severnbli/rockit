using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformUpdatesBufferComponent> PlatformUpdatesBufferComponentPool;
        public readonly ProtoIt PlatformUpdatesBuffers = new (It.Inc<PlatformUpdatesBufferComponent>());
    }
}