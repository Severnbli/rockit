using System;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Monos;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct LevelButtonComponent
    {
        public LevelButtonView View;
    }
}