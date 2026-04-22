using System;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Monos;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct PlatformComponent
    {
        public Platform Platform;
    }
}