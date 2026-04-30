using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class Vector3TweenSettings : TweenSettings
    {
        public Vector3 To;
        public Vector3 From;
    }
}