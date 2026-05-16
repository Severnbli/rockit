using System;
using Leopotam.EcsProto.Unity;
using TMPro;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct DropdownComponent
    {
        public TMP_Dropdown Dropdown;
    }
}