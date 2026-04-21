using _Project.Scripts.Runtime.Features.Physics.Moving.Platforms.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Platforms
{
    public class PlatformsMovingAspect : ProtoAspectInject
    {
        public readonly ProtoPool<ChangesBufferComponent> UpdatesBufferComponentPool;
        public readonly ProtoPool<PositionChangeComponent> PositionChangeComponentPool;
        public readonly ProtoPool<RotationChangeComponent> RotationChangeComponentPool;
        public readonly ProtoPool<ScaleChangeComponent> ScaleChangeComponentPool;
        public readonly ProtoIt UpdatesBuffers = new (It.Inc<ChangesBufferComponent>());
        public readonly ProtoIt PositionChanges = new (It.Inc<PositionChangeComponent>());
        public readonly ProtoIt RotationChanges = new (It.Inc<RotationChangeComponent>());
        public readonly ProtoIt ScaleChanges = new (It.Inc<ScaleChangeComponent>());
        public readonly ProtoItExc PositionChangeCreatables = new (It.Inc<PlatformComponent, ChangesBufferComponent>(), It.Exc<PositionChangeComponent>());
        public readonly ProtoItExc RotationChangeCreatables = new (It.Inc<PlatformComponent, ChangesBufferComponent>(), It.Exc<RotationChangeComponent>());
        public readonly ProtoItExc ScaleChangeCreatables = new (It.Inc<PlatformComponent, ChangesBufferComponent>(), It.Exc<ScaleChangeComponent>());
    }
}