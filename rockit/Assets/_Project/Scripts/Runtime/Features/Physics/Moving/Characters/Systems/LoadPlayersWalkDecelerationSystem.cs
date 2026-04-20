using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public class LoadPlayersWalkDecelerationSystem : IProtoRunSystem
    {
        [DI] private readonly SharedAspect _sAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly MovingSharedAspect _msAspect;
        private readonly PlayerMovingConfig _pmConfig;

        public LoadPlayersWalkDecelerationSystem(PlayerMovingConfig pmConfig)
        {
            _pmConfig = pmConfig;
        }

        public void Run()
        {
            foreach (var e in _sAspect.Players)
            {
                ref var mComponent = ref _msAspect.MoveComponentPool.GetOrAdd(e);
                mComponent.WalkDeceleration = _pmConfig.WalkDeceleration;
            }
        }
    }
}