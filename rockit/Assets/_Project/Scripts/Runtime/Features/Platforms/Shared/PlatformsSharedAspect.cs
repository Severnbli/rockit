using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared
{
    public class PlatformsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformComponent> PlatformComponentPool;
        public readonly ProtoPool<PositionPlatformTag> PositionPlatformTagPool;
        public readonly ProtoPool<RotationPlatformTag> RotationPlatformTagPool;
        public readonly ProtoPool<ScalePlatformTag> ScalePlatformTagPool;
        public readonly ProtoIt Platforms = new (It.Inc<PlatformComponent>());
        public readonly ProtoIt PositionPlatforms = new (It.Inc<PlatformComponent, PositionPlatformTag>());
        public readonly ProtoIt RotationPlatforms = new (It.Inc<PlatformComponent, RotationPlatformTag>());
        public readonly ProtoIt ScalePlatforms = new (It.Inc<PlatformComponent, ScalePlatformTag>());
    }
}