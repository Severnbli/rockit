using System;
using Leopotam.EcsProto.Unity;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Dropdowns.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct DropdownComponent
    {
        public Dropdown Dropdown;
    }
}