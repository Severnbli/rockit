using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public class LoadPlayersWalkDecelerationSystem : IProtoInitSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        private readonly PlayerMovingConfig _pmConfig;

        public LoadPlayersWalkDecelerationSystem(PlayerMovingConfig pmConfig)
        {
            _pmConfig = pmConfig;
        }

        public void Init(IProtoSystems systems)
        {
            
        }
    }
}