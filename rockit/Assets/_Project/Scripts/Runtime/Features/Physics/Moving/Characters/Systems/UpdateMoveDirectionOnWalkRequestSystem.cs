using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using _Project.Scripts.Runtime.Shared.Utils.Moving;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public class UpdateMoveDirectionOnWalkRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly MovingSharedAspect _mSharedAspect;
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
                if (!_mSharedAspect.Walkables.Has(tarE)) continue;

                ref var mComponent = ref _mSharedAspect.MoveComponentPool.GetOrAdd(tarE);
                ref var wRequest = ref _cmrAspect.WalkRequestPool.Get(reqE);
                mComponent.Direction = CharactersMovingUtils.GetMoveDirectionXByFloat(wRequest.Factor);
            }
        }
    }
}