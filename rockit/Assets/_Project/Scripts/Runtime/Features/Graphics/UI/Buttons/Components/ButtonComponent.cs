using System;
using Leopotam.EcsProto.Unity;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct ButtonComponent
    {
        public Button Button;
    }
}