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
        public readonly ProtoIt SpriteGlowActivePositionPlatforms = new (It.Inc<PlatformComponent, PositionPlatformTag, ActivePlatformTag, SpriteGlowComponent>());
        public readonly ProtoIt SpriteGlowActiveRotationPlatforms = new (It.Inc<PlatformComponent, RotationPlatformTag, ActivePlatformTag, SpriteGlowComponent>());
        public readonly ProtoIt PlatformColorChangeTimeouts = new (It.Inc<PlatformColorChangeComponent>());
        public readonly ProtoItExc SpriteGlowPlatformWithoutSpriteGlowChanges = new (It.Inc<PlatformComponent, SpriteGlowComponent>(), It.Exc<SpriteGlowChangeComponent>());
    }
}