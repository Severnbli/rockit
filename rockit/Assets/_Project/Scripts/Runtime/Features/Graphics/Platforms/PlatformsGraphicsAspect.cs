using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms
{
    public sealed class PlatformsGraphicsAspect : ProtoAspectInject
    {
        public readonly ProtoIt SpriteGlowPlatforms = new (It.Inc<PlatformComponent, SpriteGlowComponent>());
    }
}