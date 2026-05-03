using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    [Serializable]
    public class TweenPipeline
    {
        [SerializeReference, ListDrawerSettings(ShowFoldout = true)] 
        private ITweenPipelineStep[] _steps;
        
        public ITweenPipelineStep[] Steps => _steps;
    }
}