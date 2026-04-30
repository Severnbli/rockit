using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class Vector3TweenSettings : TweenSettings
    {
        [SerializeField] private Vector3 _to;
        [SerializeField] private Vector3 _from;

        public Vector3 To => _to;
        public Vector3 From => _from;
    }
}