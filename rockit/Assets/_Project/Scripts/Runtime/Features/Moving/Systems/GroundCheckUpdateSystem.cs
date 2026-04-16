using _Project.Scripts.Runtime.Features.Moving.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Moving.Systems
{
    public sealed class GroundCheckUpdateSystem : IProtoRunSystem
    {
        [DI] private readonly MovingAspect _aspect;
        private readonly SharedMovingConfig _sharedMovingConfig;

        public GroundCheckUpdateSystem(SharedMovingConfig sharedMovingConfig)
        {
            _sharedMovingConfig = sharedMovingConfig;
        }

        public void Run()
        {
            
        }
    }
}