using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct Rigidbody2DComponent
    {
        public Rigidbody2D Rigidbody2D;
    }
}