using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoRunSystem
    {
        private readonly TimeService _timeService;

        public SendJumpRequestByJumpBufferingSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            
        }
    }
}