using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public class LoadPlayersWalkDecelerationOnInitSystem : IProtoInitSystem
    {
        private readonly PlayerMovingConfig _pmConfig;

        public LoadPlayersWalkDecelerationOnInitSystem(PlayerMovingConfig pmConfig)
        {
            _pmConfig = pmConfig;
        }

        public void Init(IProtoSystems systems)
        {
            
        }
    }
}