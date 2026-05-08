using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Steps
{
    [Serializable]
    public abstract class TweenStep : ITweenPipelineStep
    {
        [SerializeField] private TweenStepConnector _connector = TweenStepConnector.Append;
        
        public bool TryDoStep(Sequence sequence, GameObject go, Dictionary<Type, Component> goCache)
        {
            if (!TryDoTween(go, goCache, out var tween)) return false;

            switch (_connector)
            {
                case TweenStepConnector.Append:
                {
                    sequence.Append(tween);
                    break;
                }
                case TweenStepConnector.Join:
                {
                    sequence.Join(tween);
                    break;
                }
            }
            
            return true;
        }
        
        protected abstract bool TryDoTween(GameObject go, Dictionary<Type, Component> goCache, out Tween tween);
    }
}