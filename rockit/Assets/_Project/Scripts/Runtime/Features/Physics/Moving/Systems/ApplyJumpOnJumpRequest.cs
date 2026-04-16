using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyJumpOnJumpRequest : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly MovingAspect _mAspect;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = _mrAspect.World();
        }
        
        public void FixedRun()
        {
            foreach (var reqE in _mrAspect.JumpRequests)
            {
                
            }
        }
    }
}