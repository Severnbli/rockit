using _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public class UpdateRotationPlatformColorWithSpriteGlowSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        [DI] private readonly SpritesGlowAspect _sgAspect;
        private readonly PlatformsGraphicsConfig _pgConfig;

        public UpdateRotationPlatformColorWithSpriteGlowSystem(PlatformsGraphicsConfig pgConfig)
        {
            _pgConfig = pgConfig;
        }

        public void Run()
        {
            foreach (var e in _pgAspect.SpriteGlowActiveRotationPlatforms)
            {
                ref var pccComponent = ref _pgAspect.PlatformColorChangeComponentPool.GetOrAdd(e);
                if (pccComponent.Blocked || pccComponent.RotationColorWas) continue;

                pccComponent.Blocked = true;
                pccComponent.RotationColorWas = true;
                
                ref var sgcComponent = ref _sgAspect.SpriteGlowChangeComponentPool.GetOrAdd(e);
                sgcComponent.Target = _pgConfig.RotColor;
                sgcComponent.Speed = _pgConfig.TransitionSpeed;
            }
        }
    }
}