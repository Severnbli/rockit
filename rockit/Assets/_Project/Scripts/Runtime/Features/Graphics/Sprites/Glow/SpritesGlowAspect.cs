using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Components;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow
{
    public sealed class SpritesGlowAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpriteGlowComponent> SpriteGlowComponentPool;
        public readonly ProtoIt SpriteGlows = new (It.Inc<SpriteGlowComponent>());
    }
}