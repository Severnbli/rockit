using _Project.Scripts.Runtime.Features.Graphics.Particles.Components;
using _Project.Scripts.Runtime.Features.Physics.Shared.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared
{
    public sealed class PlatformsSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformComponent> PlatformComponentPool;
        public readonly ProtoPool<PlatformStatesComponent> PlatformStatesComponentPool;
        public readonly ProtoPool<PositionPlatformTag> PositionPlatformTagPool;
        public readonly ProtoPool<RotationPlatformTag> RotationPlatformTagPool;
        public readonly ProtoPool<ScalePlatformTag> ScalePlatformTagPool;
        public readonly ProtoPool<ActivePlatformTag> ActivePlatformTagPool;
        public readonly ProtoPool<PlatformsAreaTag> PlatformsAreaTagPool;
        public readonly ProtoIt Platforms = new (It.Inc<PlatformComponent>());
        public readonly ProtoIt PlatformStates = new (It.Inc<PlatformStatesComponent>());
        public readonly ProtoIt PlatformsWithPlatformStates = new (It.Inc<PlatformComponent, PlatformStatesComponent>());
        public readonly ProtoIt PositionPlatforms = new (It.Inc<PlatformComponent, PositionPlatformTag>());
        public readonly ProtoIt RotationPlatforms = new (It.Inc<PlatformComponent, RotationPlatformTag>());
        public readonly ProtoIt ScalePlatforms = new (It.Inc<PlatformComponent, ScalePlatformTag>());
        public readonly ProtoIt ActivePlatforms = new (It.Inc<PlatformComponent, ActivePlatformTag>());
        public readonly ProtoIt ActivePositionPlatforms = new (It.Inc<PlatformComponent, ActivePlatformTag, PositionPlatformTag>());
        public readonly ProtoIt ActiveRotationPlatforms = new (It.Inc<PlatformComponent, ActivePlatformTag, RotationPlatformTag>());
        public readonly ProtoIt ActiveScalePlatforms = new (It.Inc<PlatformComponent, ActivePlatformTag, ScalePlatformTag>());
        public readonly ProtoItExc InactivePlatforms = new (It.Inc<PlatformComponent>(), It.Exc<ActivePlatformTag>());
        public readonly ProtoIt PlatformsAreaParticleSystems = new (It.Inc<PlatformsAreaTag, ParticleSystemComponent>());
        public readonly ProtoIt PlatformsAreaColliders = new (It.Inc<PlatformsAreaTag, Collider2DComponent>());
    }
}