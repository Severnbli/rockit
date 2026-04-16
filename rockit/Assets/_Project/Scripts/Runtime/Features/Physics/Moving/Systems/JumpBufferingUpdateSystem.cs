using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class JumpBufferingUpdateSystem : IProtoRunSystem
    {
        [DI] private MovingAspect _mAspect; 
        private readonly TimeService _tService;
        private readonly SharedMovingConfig _smConfig;

        public JumpBufferingUpdateSystem(TimeService tService, SharedMovingConfig smConfig)
        {
            _tService = tService;
            _smConfig = smConfig;
        }

        public void Run()
        {
            foreach (var e in _mAspect.JumpBuffers)
            {
                ref var jbComponent = ref _mAspect.JumpBufferingComponentPool.Get(e);
                
                if (!MovingUtils.JumpBufferingTimeExpired(jbComponent, _tService, _smConfig)) continue;
                
                _mAspect.JumpBufferingComponentPool.Del(e);
            }
        }
    }
}