using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Graphics.Shared.Configs;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Shared;
using _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Sprites;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Systems
{
    public sealed class CompleteSpriteGlowChangeOnRunSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly SpritesGlowAspect _sgAspect;
        private readonly ColorConfig _cConfig;
        private ProtoWorld _world;

        public CompleteSpriteGlowChangeOnRunSystem(ColorConfig cConfig)
        {
            _cConfig = cConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var e in _sgAspect.SpriteGlowWithSpriteGlowChanges)
            {
                ref var sgComponent = ref _sgAspect.SpriteGlowComponentPool.Get(e);
                ref var sgcComponent = ref _sgAspect.SpriteGlowChangeComponentPool.Get(e);
                
                if (!ColorUtils.Equals(sgComponent.SpriteGlow.GlowColor, sgcComponent.Target, _cConfig.ColorChangeTolerance))
                {
                    continue;
                }
                
                _sgAspect.SpriteGlowChangeComponentPool.Del(e);
                var tarE = _world.PackEntityWithWorld(e);
                SpritesGlowUtils.CreateSpriteGlowChangeCompletedRequest(_rAspect, tarE);
            }
        }
    }
}