using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct AudioSourceComponent
    {
        public AudioSource AudioSource;
    }
}