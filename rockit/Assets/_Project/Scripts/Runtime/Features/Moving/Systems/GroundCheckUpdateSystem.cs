using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Moving.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class GroundCheckUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _aspect;
        private readonly SharedMovingConfig _sharedMovingConfig;
        private readonly TimeService _timeService;

        public GroundCheckUpdateSystem(SharedMovingConfig sharedMovingConfig, TimeService timeService)
        {
            _sharedMovingConfig = sharedMovingConfig;
            _timeService = timeService;
        }

        public void Run()
        {
            
        }
    }
}