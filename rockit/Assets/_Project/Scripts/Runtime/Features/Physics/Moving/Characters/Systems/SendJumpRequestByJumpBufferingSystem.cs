using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoInitSystem, IProtoRunSystem
    {
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = _cmAspect.World();
        }

        public void Run()
        {
            foreach (var e in _cmAspect.JumpBufferingGroundCheckResults)
            {
                ref var gcResult = ref _cmAspect.GroundCheckResultComponentPool.Get(e);
                ref var jbComponent = ref _cmAspect.JumpBufferingComponentPool.Get(e);

                if (!gcResult.Grounded) continue;
                
                MovingUtils.CreateJumpRequest(_rAspect, _world.PackEntityWithWorld(e), jbComponent.Request);
                _cmAspect.JumpBufferingComponentPool.Del(e);
            }
        }
    }
}