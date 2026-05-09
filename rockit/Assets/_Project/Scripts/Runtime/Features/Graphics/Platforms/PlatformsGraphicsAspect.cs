using _Project.Scripts.Runtime.Features.Graphics.Platforms.Components;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms
{
    public sealed class PlatformsGraphicsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<PlatformColorChangeComponent> PlatformColorChangeComponentPool;
        public readonly ProtoIt SpriteGlowPlatforms = new (It.Inc<PlatformComponent, SpriteGlowComponent>());
        public readonly ProtoItExc SpriteGlowPlatformWithoutSpriteGlowChanges = new (It.Inc<PlatformComponent, SpriteGlowComponent>(), It.Exc<SpriteGlowChangeComponent>());
    }
}