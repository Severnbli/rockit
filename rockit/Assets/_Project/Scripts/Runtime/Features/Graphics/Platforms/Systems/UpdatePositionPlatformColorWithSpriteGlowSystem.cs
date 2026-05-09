using _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public sealed class UpdatePositionPlatformColorWithSpriteGlowSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        [DI] private readonly SpritesGlowAspect _sgAspect;
        private readonly PlatformsGraphicsConfig _pgConfig;

        public UpdatePositionPlatformColorWithSpriteGlowSystem(PlatformsGraphicsConfig pgConfig)
        {
            _pgConfig = pgConfig;
        }

        public void Run()
        {
            foreach (var e in _pgAspect.SpriteGlowActivePositionPlatforms)
            {
                ref var pccComponent = ref _pgAspect.PlatformColorChangeComponentPool.GetOrAdd(e);
                if (pccComponent.Blocked || pccComponent.PositionColorWas) continue;

                pccComponent.Blocked = true;
                pccComponent.PositionColorWas = true;
                
                ref var sgcComponent = ref _sgAspect.SpriteGlowChangeComponentPool.GetOrAdd(e);
                sgcComponent.Target = _pgConfig.PosColor;
                sgcComponent.Speed = _pgConfig.TransitionSpeed;
            }
        }
    }
}