using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Platforms.Systems
{
    public sealed class PlatformColorChangeTimeoutExpireSystem : IProtoRunSystem
    {
        [DI] private readonly PlatformsGraphicsAspect _pgAspect;
        private readonly TimeService _tService;

        public PlatformColorChangeTimeoutExpireSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void Run()
        {
            foreach (var e in _pgAspect.PlatformColorChangeTimeouts)
            {
                ref var pcctComponent = ref _pgAspect.PlatformColorChangeTimeoutComponentPool.Get(e);

                if (!_tService.Expired(pcctComponent.CreationTime, pcctComponent.Timeout)) continue;

                ref var pccComponent = ref _pgAspect.PlatformColorChangeComponentPool.GetOrAdd(e);
                pccComponent.Blocked = false;
                _pgAspect.PlatformColorChangeTimeoutComponentPool.Del(e);
            }
        }
    }
}