using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Shared.Utils;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class DashTimeoutExpireSystem : IProtoRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private readonly TimeService _tService;

        public DashTimeoutExpireSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void Run()
        {
            foreach (var e in _cmAspect.DashTimeouts)
            {
                ref var dtComponent = ref _cmAspect.DashTimeoutComponentPool.Get(e);
                if (!CharactersMovingUtils.DashTimeoutExpired(dtComponent, _tService)) continue;
                _cmAspect.DashTimeoutComponentPool.Del(e);
            }
        }
    }
}