using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Types;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Animations;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Steps
{
    [Serializable]
    public class Vector3ScaleStep : TweenStep
    {
        [SerializeField] private Vector3TweenSettings _settings;
        
        protected override bool TryDoTween(GameObject go, Dictionary<Type, Component> goCache, out Tween tween)
        {
            tween = null;
            
            if (!go.TryGetComponentWithCache(goCache, out Transform tf)) return false;
            
            tf.ScaleTween(_settings);
            return true;
        }
    }
}