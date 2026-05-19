using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Particles.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct ParticleSystemComponent
    {
        public ParticleSystem ParticleSystem;
    }
}