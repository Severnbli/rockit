using System;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Localization.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct LocalizationItemComponent
    {
        public string Key;
    }
}