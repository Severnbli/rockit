using System;
using _Project.Scripts.Runtime.Features.Platforms.Shared.Monos;
using _Project.Scripts.Runtime.Shared.Tools;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct PlatformComponent
    {
        public Platform Platform;
        public SequenceElement<Vector3> CurPosState;
        public SequenceElement<Quaternion> CurRotState;
        public SequenceElement<Vector3> CurScaleState;
    }
}