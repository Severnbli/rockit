using System;
using Leopotam.EcsProto.Unity;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct AnimatorComponent
    {
        public Animator Animator;
    }
}