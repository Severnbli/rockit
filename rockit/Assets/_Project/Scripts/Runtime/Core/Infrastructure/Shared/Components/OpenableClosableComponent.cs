using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct OpenableClosableComponent
    {
        public OpenableClosable OpenableClosable;
    }
}