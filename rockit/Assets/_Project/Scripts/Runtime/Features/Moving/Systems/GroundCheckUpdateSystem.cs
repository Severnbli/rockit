using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Moving.Configs;
using _Project.Scripts.Runtime.Shared.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class GroundCheckUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _movingAspect;
        private readonly SharedMovingConfig _sharedMovingConfig;
        private readonly TimeService _timeService;
        private readonly LayersConfig _layersConfig;

        public GroundCheckUpdateSystem(SharedMovingConfig sharedMovingConfig, TimeService timeService, LayersConfig layersConfig)
        {
            _sharedMovingConfig = sharedMovingConfig;
            _timeService = timeService;
            _layersConfig = layersConfig;
        }

        public void Run()
        {
            
        }
    }
}