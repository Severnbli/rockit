using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformUpdatesBufferComponent> PlatformUpdatesBufferComponentPool;
        public readonly ProtoPool<PlatformPositionChangeComponent> PlatformPositionChangeComponentPool;
        public readonly ProtoPool<PlatformRotationChangeComponent> PlatformRotationChangeComponentPool;
        public readonly ProtoPool<PlatformScaleChangeComponent> PlatformScaleChangeComponentPool;
        public readonly ProtoIt PlatformUpdatesBuffers = new (It.Inc<PlatformUpdatesBufferComponent>());
        public readonly ProtoIt PlatformPositionChanges = new (It.Inc<PlatformPositionChangeComponent>());
        public readonly ProtoIt PlatformRotationChanges = new (It.Inc<PlatformRotationChangeComponent>());
        public readonly ProtoIt PlatformScaleChanges = new (It.Inc<PlatformScaleChangeComponent>());
        public readonly ProtoItExc PositionChangeCreatables = new (It.Inc<PlatformComponent, PlatformUpdatesBufferComponent>(), It.Exc<PlatformPositionChangeComponent>());
        public readonly ProtoItExc RotationChangeCreatables = new (It.Inc<PlatformComponent, PlatformUpdatesBufferComponent>(), It.Exc<PlatformRotationChangeComponent>());
        public readonly ProtoItExc ScaleChangeCreatables = new (It.Inc<PlatformComponent, PlatformUpdatesBufferComponent>(), It.Exc<PlatformScaleChangeComponent>());
    }
}