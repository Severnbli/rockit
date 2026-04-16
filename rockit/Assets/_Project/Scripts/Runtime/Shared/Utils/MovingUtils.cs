using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Moving.Components;
using _Project.Scripts.Runtime.Features.Moving.Configs;
using _Project.Scripts.Runtime.Features.Moving.Requests;
using _Project.Scripts.Runtime.Shared.Configs;
using _Project.Scripts.Runtime.Shared.Extensions;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

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
    }
}