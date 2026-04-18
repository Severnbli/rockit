using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct TransformComponent
    {
        public Transform Transform;
    }
}