using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Steps
{
    [Serializable]
    public class IntervalStep : ITweenPipelineStep
    {
        [SerializeField] private float _duration;
        
        public bool TryDoStep(Sequence sequence, GameObject go, Dictionary<Type, Component> goCache)
        {
            sequence.AppendInterval(_duration);
            return true;
        }
    }
}