using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public class LoadPlayersWalkDecelerationSystem : IProtoRunSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        [DI] private readonly MovingAspect _mAspect;
        private readonly PlayerMovingConfig _pmConfig;

        public LoadPlayersWalkDecelerationSystem(PlayerMovingConfig pmConfig)
        {
            _pmConfig = pmConfig;
        }

        public void Run()
        {
            
        }
    }
}