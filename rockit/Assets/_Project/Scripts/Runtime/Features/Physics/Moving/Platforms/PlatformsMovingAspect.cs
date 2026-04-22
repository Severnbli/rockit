using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformChangesBufferComponent> PlatformChangesBufferComponentPool;
        public readonly ProtoPool<PlatformPositionChangeComponent> PlatformPositionChangeComponentPool;
        public readonly ProtoPool<PlatformRotationChangeComponent> PlatformRotationChangeComponentPool;
        public readonly ProtoPool<PlatformScaleChangeComponent> PlatformScaleChangeComponentPool;
        public readonly ProtoIt PlatformChangesBuffers = new (It.Inc<PlatformChangesBufferComponent>());
        public readonly ProtoIt PlatformPositionChanges = new (It.Inc<PlatformPositionChangeComponent>());
        public readonly ProtoIt PlatformRotationChanges = new (It.Inc<PlatformRotationChangeComponent>());
        public readonly ProtoIt PlatformScaleChanges = new (It.Inc<PlatformScaleChangeComponent>());
        public readonly ProtoItExc PlatformPositionChangeCreatables = new (It.Inc<PlatformComponent, PlatformStatesComponent, PlatformChangesBufferComponent>(), It.Exc<PlatformPositionChangeComponent>());
        public readonly ProtoItExc PlatformRotationChangeCreatables = new (It.Inc<PlatformComponent, PlatformStatesComponent, PlatformChangesBufferComponent>(), It.Exc<PlatformRotationChangeComponent>());
        public readonly ProtoItExc PlatformScaleChangeCreatables = new (It.Inc<PlatformComponent, PlatformStatesComponent, PlatformChangesBufferComponent>(), It.Exc<PlatformScaleChangeComponent>());
    }
}