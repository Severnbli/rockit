using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class DashTimeoutExpireSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        private readonly TimeService _tService;

        public DashTimeoutExpireSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void Run()
        {
            foreach (var e in _mAspect.DashTimeouts)
            {
                ref var dtComponent = ref _mAspect.DashTimeoutComponentPool.Get(e);
                if (!MovingUtils.DashTimeoutExpired(dtComponent, _tService)) continue;
                _mAspect.DashTimeoutComponentPool.Del(e);
            }
        }
    }
}