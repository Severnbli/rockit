using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared
{
    public class SpritesSharedAspect : ProtoAspectInject
    {
        public readonly ProtoPool<FaceComponent> FaceComponentPool;
        public readonly ProtoIt Faces = new (It.Inc<FaceComponent>());
    }
}