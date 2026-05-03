using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    [Serializable]
    public class TweenPipeline
    {
        [SerializeField] private ITweenPipelineStep[] _steps;
        
        public ITweenPipelineStep[] Steps => _steps;
    }
}