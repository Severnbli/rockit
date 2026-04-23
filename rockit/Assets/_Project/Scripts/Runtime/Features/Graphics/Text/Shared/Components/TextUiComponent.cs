using System;
using Leopotam.EcsProto.Unity;
using TMPro;

namespace _Project.Scripts.Runtime.Features.Graphics.Text.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct TextUiComponent
    {
        public TextMeshProUGUI Text;
    }
}