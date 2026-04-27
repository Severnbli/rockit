using System;
using Leopotam.EcsProto.Unity;
using TMPro;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct LevelButtonComponent
    {
        public TextMeshProUGUI IdText;
    }
}