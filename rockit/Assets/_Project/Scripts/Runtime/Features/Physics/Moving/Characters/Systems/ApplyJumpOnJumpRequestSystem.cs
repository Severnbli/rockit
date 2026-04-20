using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using _Project.Scripts.Runtime.Features.Physics.Shared;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems
{
    public sealed class ApplyJumpOnJumpRequestSystem : IProtoInitSystem, IProtoFixedRunSystem
    {
        [DIRequests] private readonly CharactersMovingRequestsAspect _cmrAspect;
        [DIRequests] private readonly CoreRequestsAspect _crAspect;
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly CharactersMovingAspect _cmAspect;
        [DI] private readonly PhysicsSharedAspect _psAspect;
        private ProtoWorld _world;
        private readonly TimeService _timeService;

        public ApplyJumpOnJumpRequestSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.World();
        }
        
        public void FixedRun()
        {
            foreach (var reqE in _cmrAspect.JumpRequests)
            {
                if (!_crAspect.TryCompareRequestWorld(reqE, _world, out var tarE)) continue;
                if (!_cmAspect.Jumpables.Has(tarE)) continue;
                
                ref var jRequest = ref _cmrAspect.JumpRequestPool.Get(reqE);
                ref var gcResult = ref _cmAspect.GroundCheckResultComponentPool.Get(tarE);
                
                if (!gcResult.Grounded)
                {
                    TryCreateBuffer(jRequest, tarE);
                    continue;
                }

                ApplyJump(jRequest, tarE);
                CreateJumpAppliedRequests(tarE);
            }
        }

        private void CreateJumpAppliedRequests(ProtoEntity tarE)
        {
            MovingUtils.CreateJumpAppliedRequest(_rAspect, false, _world.PackEntityWithWorld(tarE));
            MovingUtils.CreateJumpAppliedRequest(_rAspect, true, _world.PackEntityWithWorld(tarE));
        }

        private void ApplyJump(JumpRequest jRequest, ProtoEntity tarE)
        {
            if (_cmAspect.JumpBufferingComponentPool.Has(tarE))
            {
                ref var jbComponent = ref _cmAspect.JumpBufferingComponentPool.Get(tarE);
                jRequest = jbComponent.Request;
                _cmAspect.JumpBufferingComponentPool.Del(tarE);
            }
            
            _cmAspect.JumpBufferingComponentPool.DelIfExists(tarE);
            ref var rbComponent = ref _psAspect.Rigidbody2DComponentPool.Get(tarE);
            rbComponent.Rigidbody2D.ApplyJump(jRequest.Factor);
        }

        private bool TryCreateBuffer(JumpRequest jRequest, ProtoEntity tarE)
        {
            if (jRequest.Buffered) return false;

            ref var jBuffering = ref _cmAspect.JumpBufferingComponentPool.GetOrAdd(tarE);
            jRequest.Buffered = true;
            jBuffering.Request = jRequest;
            jBuffering.CreationTiming = _timeService.UnscaledTime;
            return true;
        }
    }
}