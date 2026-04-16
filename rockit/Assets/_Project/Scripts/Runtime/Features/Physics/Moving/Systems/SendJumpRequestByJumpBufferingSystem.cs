using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        private readonly TimeService _tService;

        public SendJumpRequestByJumpBufferingSystem(TimeService tService)
        {
            _tService = tService;
        }

        public void Run()
        {
            
        }
    }
}