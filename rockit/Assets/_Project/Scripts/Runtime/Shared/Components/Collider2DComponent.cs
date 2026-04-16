using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct Collider2DComponent
    {
        public Collider2D Collider;
    }
}