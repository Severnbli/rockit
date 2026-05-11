using System;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct LevelButtonViewComponent
    {
        public LevelButtonView LevelButtonView;
    }
}