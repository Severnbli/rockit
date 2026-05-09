using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared
{
    public sealed class SpritesSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<FaceComponent> FaceComponentPool;
        
        public readonly ProtoIt Faces = new (It.Inc<FaceComponent>());
        public readonly ProtoIt CharacterMoveTransformFaces = new (It.Inc<CharacterMoveComponent, TransformComponent, FaceComponent>());
    }
}