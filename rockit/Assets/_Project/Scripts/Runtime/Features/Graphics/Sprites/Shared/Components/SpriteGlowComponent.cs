using System;
using Leopotam.EcsProto.Unity;
using SpriteGlow;

namespace _Project.Scripts.Runtime.Features.Graphics.Sprites.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct SpriteGlowComponent
    {
        public SpriteGlowEffect SpriteGlow;
    }
}