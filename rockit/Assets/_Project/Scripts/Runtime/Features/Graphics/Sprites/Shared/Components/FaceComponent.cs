using System;
using _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Enums;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct FaceComponent
    {
        public FacingDirection Direction;
    }
}