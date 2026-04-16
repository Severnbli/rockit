using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class SendJumpRequestByJumpBufferingSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _mAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly TimeService _tService;
        private readonly SharedMovingConfig _smConfig;

        public SendJumpRequestByJumpBufferingSystem(TimeService tService, SharedMovingConfig smConfig)
        {
            _tService = tService;
            _smConfig = smConfig;
        }

        public void Run()
        {
            
        }
    }
}