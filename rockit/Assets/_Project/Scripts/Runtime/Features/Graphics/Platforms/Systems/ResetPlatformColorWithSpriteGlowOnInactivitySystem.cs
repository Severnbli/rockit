using _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public sealed class ResetPlatformColorWithSpriteGlowOnInactivitySystem : IProtoRunSystem
    {
        [DI] private readonly SpritesGlowAspect _sgAspect;
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        private readonly PlatformsGraphicsConfig _pgConfig;

        public ResetPlatformColorWithSpriteGlowOnInactivitySystem(PlatformsGraphicsConfig pgConfig)
        {
            _pgConfig = pgConfig;
        }

        public void Run()
        {
            foreach (var e in _pgAspect.SpriteGlowInactivePlatforms)
            {
                _sgAspect.SpriteGlowChangeComponentPool.DelIfExists(e);
                ref var sgComponent = ref _sgAspect.SpriteGlowComponentPool.Get(e);
                sgComponent.SpriteGlow.GlowColor = _pgConfig.FallbackColor;
            }
        }
    }
}