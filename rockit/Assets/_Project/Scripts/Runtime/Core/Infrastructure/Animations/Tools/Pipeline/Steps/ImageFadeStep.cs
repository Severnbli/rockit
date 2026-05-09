using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Types;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Steps
{
    [Serializable]
    public class ImageFadeStep : TweenStep
    {
        [SerializeField] private FloatTweenSettings _settings;
        
        protected override bool TryDoTween(GameObject go, Dictionary<Type, Component> goCache, out Tween tween)
        {
            tween = null;
            
            if (!go.TryGetComponentWithCache(goCache, out Image img)) return false;
            
            tween = img.FadeTween(_settings);
            return true;
        }
    }
}