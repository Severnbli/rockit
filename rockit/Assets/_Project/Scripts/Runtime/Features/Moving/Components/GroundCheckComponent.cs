using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Moving.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct GroundCheckComponent
    {
        public Vector3 Position;
        public float Radius;
    }
}