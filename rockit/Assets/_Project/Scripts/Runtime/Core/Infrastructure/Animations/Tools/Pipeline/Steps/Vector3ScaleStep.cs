using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Types;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Steps
{
    [Serializable]
    public class Vector3ScaleStep : TweenStep
    {
        [SerializeField] private Vector3TweenSettings _settings;
        
        protected override bool TryDoTween(GameObject go, Dictionary<Type, Component> goCache, out Tween tween)
        {
            tween = null;
            
            if (!go.TryGetComponentWithCache(goCache, out Transform tf)) return false;
            
            tween = tf.ScaleTween(_settings);
            return true;
        }
    }
}