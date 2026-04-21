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
        public SequenceElement<Vector3> StartPosState;
        public SequenceElement<Vector3> CurrPosState;
        public SequenceElement<Quaternion> StartRotState;
        public SequenceElement<Quaternion> CurrRotState;
        public SequenceElement<Vector3> StartScaleState;
        public SequenceElement<Vector3> CurrScaleState;
    }
}