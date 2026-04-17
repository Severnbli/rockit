using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyWalkOnWalkRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        [DI] private readonly MovingAspect _mAspect;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }

        public void FixedRun()
        {
            foreach (var reqE in _mrAspect.WalkRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_mAspect.Walkables.Has(tarE)) continue;

                ref var wRequest = ref _mrAspect.WalkRequestPool.Get(reqE);
                ApplyWalk(wRequest, tarE);
            }
        }

        private void ApplyWalk(WalkRequest wRequest, ProtoEntity tarE)
        {
            ref var rComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
            rComponent.Rigidbody2D.ApplyWalk(wRequest.Factor);
        }
    }
}