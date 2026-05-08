using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    [Serializable]
    public class TweenPipeline
    {
        [SerializeReference, ListDrawerSettings(ShowFoldout = true)] 
        private ITweenPipelineStep[] _steps;

        [SerializeField] private int _loops = 1;
        [SerializeField] private LoopType _loopType = LoopType.Restart;
        
        public ITweenPipelineStep[] Steps => _steps;
        public int Loops => _loops;
        public LoopType LoopType => _loopType;
    }
}