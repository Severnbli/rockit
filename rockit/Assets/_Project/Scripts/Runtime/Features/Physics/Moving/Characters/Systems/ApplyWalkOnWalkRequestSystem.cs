using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyWalkOnWalkRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void FixedRun()
        {
            foreach (var reqE in _cmrAspect.WalkRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cmAspect.Walkables.Has(tarE)) continue;

                ref var wRequest = ref _cmrAspect.WalkRequestPool.Get(reqE);
                ref var cvComponent = ref _cmAspect.CharacterVelocityComponentPool.GetOrAdd(tarE);
                ref var cmComponent = ref _cmAspect.CharacterMoveComponentPool.GetOrAdd(tarE);
                
                cvComponent.Velocity.x = wRequest.Factor;
                cmComponent.WalkDeceleration = wRequest.Deceleration;
            }
        }
    }
}