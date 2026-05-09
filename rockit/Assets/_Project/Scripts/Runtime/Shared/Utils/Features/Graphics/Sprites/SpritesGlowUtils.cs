using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Requests;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Shared.Utils.Features.Graphics.Sprites
{
    public static class SpritesGlowUtils
    {
        public static ProtoEntity CreateSpriteGlowChangeCompletedRequest(RequestsAspect aspect, 
            ProtoPackedEntityWithWorld targetEntity, SpriteGlowChangeCompletedRequest prepared)
        {
            return aspect.CreateRequest(
                aspect.SpritesGlowRequestsAspect.SpriteGlowChangeCompletedRequestPool,
                targetEntity: targetEntity,
                prepared: prepared
            );
        }
    }
}