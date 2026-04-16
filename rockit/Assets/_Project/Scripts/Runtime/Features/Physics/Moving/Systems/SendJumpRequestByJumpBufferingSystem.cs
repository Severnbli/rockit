using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly TimeService _tService;
        private readonly SharedMovingConfig _smConfig;
        private ProtoWorld _world;

        public SendJumpRequestByJumpBufferingSystem(TimeService tService, SharedMovingConfig smConfig)
        {
            _tService = tService;
            _smConfig = smConfig;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = _mAspect.World();
        }

        public void Run()
        {
            foreach (var e in _mAspect.JumpBufferingGroundCheckResults)
            {
                ref var gcResult = ref _mAspect.GroundCheckResultComponentPool.Get(e);
                ref var jbComponent = ref _mAspect.JumpBufferingComponentPool.Get(e);

                if (gcResult.Grounded)
                {
                    jbComponent.Request.Buffered = true;
                    MovingUtils.CreateJumpRequest(_rAspect, _world.PackEntityWithWorld(e), jbComponent.Request);
                }
                else
                {
                    if (!MovingUtils.JumpBufferingTimeExpired(jbComponent, _tService, _smConfig)) continue;
                }
                
                _mAspect.JumpBufferingComponentPool.Del(e);
            }
        }
    }
}