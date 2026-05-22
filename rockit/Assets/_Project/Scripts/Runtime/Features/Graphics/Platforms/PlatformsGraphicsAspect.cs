using _Project.Scripts.Runtime.Features.Graphics.Platforms.Components;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms
{
    public sealed class PlatformsGraphicsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformColorChangeComponent> PlatformColorChangeComponentPool;
        public readonly ProtoPool<PlatformColorChangeTimeoutComponent> PlatformColorChangeTimeoutComponentPool;
        public readonly ProtoIt SpriteGlowPlatforms = new (It.Inc<PlatformComponent, SpriteGlowComponent>());
        public readonly ProtoItExc SpriteGlowActivePositionPlatforms = new (It.Inc<PlatformComponent, PositionPlatformTag, ActivePlatformTag, SpriteGlowComponent>(), It.Exc<PlatformColorChangeTimeoutComponent>());
        public readonly ProtoItExc SpriteGlowActiveRotationPlatforms = new (It.Inc<PlatformComponent, RotationPlatformTag, ActivePlatformTag, SpriteGlowComponent>(), It.Exc<PlatformColorChangeTimeoutComponent>());
        public readonly ProtoItExc SpriteGlowActiveScalePlatforms = new (It.Inc<PlatformComponent, ScalePlatformTag, ActivePlatformTag, SpriteGlowComponent>(),It.Exc<PlatformColorChangeTimeoutComponent>());
        public readonly ProtoItExc PlatformColorChangeResetables = new (It.Inc<PlatformComponent, PlatformColorChangeComponent>(), It.Exc<PlatformColorChangeTimeoutComponent>());
        public readonly ProtoItExc InactivePlatformsColorChangeTimeouts = new (It.Inc<PlatformColorChangeTimeoutComponent>(), It.Exc<ActivePlatformTag>());
        public readonly ProtoIt PlatformColorChangeTimeouts = new (It.Inc<PlatformColorChangeTimeoutComponent>());
        public readonly ProtoItExc SpriteGlowPlatformWithoutSpriteGlowChanges = new (It.Inc<PlatformComponent, SpriteGlowComponent>(), It.Exc<SpriteGlowChangeComponent>());
        public readonly ProtoItExc SpriteGlowInactivePlatforms = new (It.Inc<PlatformComponent, SpriteGlowComponent>(), It.Exc<ActivePlatformTag>());
        public readonly ProtoIt PlatformColorChanges = new (It.Inc<PlatformColorChangeComponent>());
    }
}