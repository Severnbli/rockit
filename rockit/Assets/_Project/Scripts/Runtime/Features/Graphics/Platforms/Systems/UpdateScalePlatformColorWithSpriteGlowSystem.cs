using _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public class UpdateScalePlatformColorWithSpriteGlowSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        [DI] private readonly SpritesGlowAspect _sgAspect;
        private readonly PlatformsGraphicsConfig _pgConfig;

        public UpdateScalePlatformColorWithSpriteGlowSystem(PlatformsGraphicsConfig pgConfig)
        {
            _pgConfig = pgConfig;
        }

        public void Run()
        {
            foreach (var e in _pgAspect.SpriteGlowActiveScalePlatforms)
            {
                ref var pccComponent = ref _pgAspect.PlatformColorChangeComponentPool.GetOrAdd(e);
                if (pccComponent.Blocked || pccComponent.ScaleColorWas) continue;

                pccComponent.Blocked = true;
                pccComponent.ScaleColorWas = true;
                
                ref var sgcComponent = ref _sgAspect.SpriteGlowChangeComponentPool.GetOrAdd(e);
                sgcComponent.Target = _pgConfig.ScaleColor;
                sgcComponent.Speed = _pgConfig.TransitionSpeed;
            }
        }
    }
}