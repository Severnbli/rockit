using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Configs;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Requests;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Enums;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Utils.Moving
{
    public static class CharactersMovingUtils
    {
        public static ProtoEntity CreateWalkRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, WalkRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.CharactersMovingRequestsAspect.WalkRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateJumpRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, JumpRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.CharactersMovingRequestsAspect.JumpRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateDashRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity = default, DashRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.CharactersMovingRequestsAspect.DashRequestPool, targetEntity, true,
                prepared);
            return entity;
        }

        public static ProtoEntity CreateDashTimeoutRequest(RequestsAspect aspect,
            ProtoPackedEntityWithWorld targetEntity, DashTimeoutRequest prepared)
        {
            var entity = aspect.CreateRequest(aspect.CharactersMovingRequestsAspect.DashTimeoutRequestPool, targetEntity, 
                false, prepared);
            return entity;
        }

        public static ProtoEntity CreateJumpAppliedRequest(RequestsAspect aspect, bool fixedRun = false,
            ProtoPackedEntityWithWorld targetEntity = default, JumpAppliedRequest prepared = default)
        {
            var entity = aspect.CreateRequest(aspect.CharactersMovingRequestsAspect.JumpAppliedRequestPool, targetEntity,
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
            SharedCharacterMovingConfig sharedCharacterMovingConfig)
        {
            return timeService.UnscaledTime - groundCheckResult.LastGroundedTiming > sharedCharacterMovingConfig.CoyoteTime;
        }

        public static bool JumpBufferingTimeExpired(JumpBufferingComponent jumpBufferingComponent,
            TimeService timeService, SharedCharacterMovingConfig sharedCharacterMovingConfig)
        {
            return timeService.UnscaledTime - jumpBufferingComponent.CreationTiming >
                   sharedCharacterMovingConfig.JumpBufferingTime;
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