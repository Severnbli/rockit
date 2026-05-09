using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Platforms.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow;
using _Project.Scripts.Runtime.Features.Platforms.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public class CreatePlatformColorChangeTimeoutOnSpriteGlowChangeCompletedRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DIRequests] private readonly SpritesGlowRequestsAspect _sgrAspect;
        [DI] private readonly PlatformsSharedAspect _psAspect;
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        private readonly TimeService _tService;
        private readonly PlatformsGraphicsConfig _pgConfig;
        private ProtoWorld _world;

        public CreatePlatformColorChangeTimeoutOnSpriteGlowChangeCompletedRequestSystem(TimeService tService, PlatformsGraphicsConfig pgConfig)
        {
            _tService = tService;
            _pgConfig = pgConfig;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void Run()
        {
            foreach (var reqE in _sgrAspect.SpriteGlowChangeCompletedRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_psAspect.Platforms.Has(tarE)) return;

                ref var pcctComponent = ref _pgAspect.PlatformColorChangeTimeoutComponentPool.GetOrAdd(tarE);
                pcctComponent.CreationTime = _tService.UnscaledTime;
                pcctComponent.Timeout = _pgConfig.StayDuration;
            }
        }
    }
}