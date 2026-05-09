using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Tags;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow
{
    public sealed class SpritesGlowRequestsAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpriteGlowChangeColorRequest> SpriteGlowChangeColorRequestPool;
        public readonly ProtoIt SpriteGlowChangeColorRequests = new (It.Inc<RequestComponent, ActiveRequestTag, RunRequestTag, SpriteGlowChangeColorRequest>());
    }
}