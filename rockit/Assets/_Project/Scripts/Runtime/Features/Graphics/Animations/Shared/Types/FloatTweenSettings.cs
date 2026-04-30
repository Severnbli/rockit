using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class FloatTweenSettings : TweenSettings
    {
        [SerializeField] private float _to;
        [SerializeField] private float _from;

        public float To => _to;
        public float From => _from;
    }
}