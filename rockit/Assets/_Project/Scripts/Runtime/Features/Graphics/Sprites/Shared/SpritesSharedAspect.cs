using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared
{
    public sealed class SpritesSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<FaceComponent> FaceComponentPool;
        public readonly ProtoPool<SpriteGlowComponent> SpriteGlowComponentPool;
        public readonly ProtoIt Faces = new (It.Inc<FaceComponent>());
        public readonly ProtoIt MoveTransformFaces = new (It.Inc<MoveComponent, FaceComponent>());
        public readonly ProtoIt SpriteGlows = new (It.Inc<SpriteGlowComponent>());
    }
}