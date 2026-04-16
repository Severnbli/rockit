using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private ProtoWorld _world;
        
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

                if (!gcResult.Grounded) continue;
                
                jbComponent.Request.Buffered = true;
                MovingUtils.CreateJumpRequest(_rAspect, _world.PackEntityWithWorld(e), jbComponent.Request);
                _mAspect.JumpBufferingComponentPool.Del(e);
            }
        }
    }
}