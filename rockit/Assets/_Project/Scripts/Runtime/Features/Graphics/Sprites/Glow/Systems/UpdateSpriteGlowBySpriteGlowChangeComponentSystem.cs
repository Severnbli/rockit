using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Shared.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Systems
{
    public sealed class UpdateSpriteGlowBySpriteGlowChangeComponentSystem : IProtoRunSystem
    {
        [DI] private readonly SpritesGlowAspect _sgAspect;
        private readonly TimeService _tService;
        private readonly ColorConfig _cConfig;

        public UpdateSpriteGlowBySpriteGlowChangeComponentSystem(TimeService tService, ColorConfig cConfig)
        {
            _tService = tService;
            _cConfig = cConfig;
        }

        public void Run()
        {
            foreach (var e in _sgAspect.SpriteGlowWithSpriteGlowChanges)
            {
                ref var sgComponent = ref _sgAspect.SpriteGlowComponentPool.Get(e);
                ref var sgcComponent = ref _sgAspect.SpriteGlowChangeComponentPool.Get(e);

                var currColor = sgComponent.SpriteGlow.GlowColor;
                var tarColor = sgcComponent.Target;

                if (ColorUtils.Equals(currColor, tarColor, _cConfig.ColorChangeTolerance))
                {
                    _sgAspect.SpriteGlowChangeComponentPool.Del(e);
                    continue;
                }

                sgComponent.SpriteGlow.GlowColor = ColorUtils.MoveTowards(
                    currColor,
                    tarColor,
                    sgcComponent.Speed * _tService.UnscaledDeltaTime
                );
            }
        }
    }
}