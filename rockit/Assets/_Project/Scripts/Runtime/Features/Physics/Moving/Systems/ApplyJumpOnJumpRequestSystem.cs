using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Systems
{
    public sealed class ApplyJumpOnJumpRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly MovingRequestsAspect _mrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DI] private readonly MovingAspect _mAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private ProtoWorld _world;
        private readonly TimeService _timeService;

        public ApplyJumpOnJumpRequestSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = _mrAspect.World();
        }
        
        public void FixedRun()
        {
            foreach (var reqE in _mrAspect.JumpRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_mAspect.Rigidbody2DGroundCheckResults.Has(tarE)) continue;
                
                ref var jRequest = ref _mrAspect.JumpRequestPool.Get(reqE);
                ref var gcResult = ref _mAspect.GroundCheckResultComponentPool.Get(tarE);
                
                if (!gcResult.Grounded)
                {
                    TryCreateBuffer(jRequest, tarE);
                    continue;
                }

                ApplyJump(jRequest, tarE);
            }
        }

        private void ApplyJump(JumpRequest jRequest, ProtoEntity tarE)
        {
            if (_mAspect.JumpBufferingComponentPool.Has(tarE))
            {
                ref var jbComponent = ref _mAspect.JumpBufferingComponentPool.Get(tarE);
                jRequest = jbComponent.Request;
            }
            
            _mAspect.JumpBufferingComponentPool.DelIfExists(tarE);
            ref var rbComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
            rbComponent.Rigidbody2D.ApplyJump(jRequest.Factor);
        }

        private bool TryCreateBuffer(JumpRequest jRequest, ProtoEntity tarE)
        {
            if (jRequest.Buffered) return false;

            ref var jBuffering = ref _mAspect.JumpBufferingComponentPool.GetOrAdd(tarE);
            jRequest.Buffered = true;
            jBuffering.Request = jRequest;
            jBuffering.CreationTiming = _timeService.UnscaledTime;
            return true;
        }
    }
}