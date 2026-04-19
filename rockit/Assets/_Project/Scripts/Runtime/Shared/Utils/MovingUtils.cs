using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class MovingUtils
    {
        public static ProtoEntity CreateWalkRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, WalkRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.WalkRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, JumpRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.JumpRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateDashRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, DashRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.DashRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateDashTimeoutRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity, DashTimeoutRequest prepared)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.DashTimeoutRequestPool, targetEntity, 
                false, prepared);
            return entity;
        }

        public static ProtoEntity CreateJumpAppliedRequest(RequestsAspect aspect, bool fixedRun = false,
            ProtoPackedEntityWithWorld targetEntity = default, JumpAppliedRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.MovingRequestsAspect.JumpAppliedRequestPool, targetEntity,
                fixedRun, prepared);
            return entity;
        }

        public static Vector3 GetGroundCheckPosition(Vector3 characterPosition, Vector3 groundCheckPosition)
        {
            return characterPosition + groundCheckPosition;
        }

        public static bool Grounded(Vector3 characterPosition, GroundCheckComponent groundCheck,
            LayersConfig layersConfig, out Collider2D groundCollider)
        {
            var position = GetGroundCheckPosition(characterPosition, groundCheck.Position);
            groundCollider = Physics2D.OverlapCircle(position, groundCheck.Radius, layersConfig.GroundLayer);
            return groundCollider != null;
        }

        public static bool CoyoteTimeExpired(GroundCheckResultComponent groundCheckResult, TimeService timeService,
            SharedMovingConfig sharedMovingConfig)
        {
            return timeService.UnscaledTime - groundCheckResult.LastGroundedTiming > sharedMovingConfig.CoyoteTime;
        }

        public static bool JumpBufferingTimeExpired(JumpBufferingComponent jumpBufferingComponent,
            TimeService timeService, SharedMovingConfig sharedMovingConfig)
        {
            return timeService.UnscaledTime - jumpBufferingComponent.CreationTiming >
                   sharedMovingConfig.JumpBufferingTime;
        }

        public static bool DashTimeoutExpired(DashTimeoutComponent dashTimeoutComponent, TimeService timeService)
        {
            return timeService.UnscaledTime - dashTimeoutComponent.CreationTime > dashTimeoutComponent.Timeout;
        }

        public static int GetMoveXDirection(MoveDirection direction)
        {
            return direction switch
            {
                MoveDirection.Left => -1,
                MoveDirection.Right => 1,
                _ => 0
            };
        }

        public static MoveDirection GetMoveDirectionByVector2(Vector2 vector)
        {
            return vector.x > 0 
                ? MoveDirection.Right 
                : MoveDirection.Left;
        }

        public static MoveDirection GetMoveDirectionXByFloat(float value)
        {
            return value > 0
                ? MoveDirection.Right
                : MoveDirection.Left;
        }
    }
}