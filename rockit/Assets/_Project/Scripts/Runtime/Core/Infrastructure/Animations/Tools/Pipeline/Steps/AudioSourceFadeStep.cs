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
    public class AudioSourceFadeStep : TweenStep
    {
        [SerializeField] private FloatTweenSettings _settings;
        
        protected override bool TryDoTween(GameObject go, Dictionary<Type, Component> goCache, out Tween tween)
        {
            tween = null;
            
            if (!go.TryGetComponentWithCache(goCache, out AudioSource aSource)) return false;

            tween = aSource.FadeTween(_settings);
            return true;
        }
    }
}