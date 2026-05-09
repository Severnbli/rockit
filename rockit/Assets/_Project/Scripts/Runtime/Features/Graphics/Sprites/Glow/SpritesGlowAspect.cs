using _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Glow
{
    public sealed class SpritesGlowAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SpriteGlowComponent> SpriteGlowComponentPool;
        public readonly ProtoPool<SpriteGlowChangeComponent> SpriteGlowChangeComponentPool;
        public readonly ProtoIt SpriteGlows = new (It.Inc<SpriteGlowComponent>());
        public readonly ProtoIt SpriteGlowChanges = new (It.Inc<SpriteGlowChangeComponent>());
        public readonly ProtoIt SpriteGlowWithSpriteGlowChanges = new (It.Inc<SpriteGlowComponent, SpriteGlowChangeComponent>());
    }
}