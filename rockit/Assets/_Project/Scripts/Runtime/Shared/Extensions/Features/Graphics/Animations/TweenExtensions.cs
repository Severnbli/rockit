using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Animations
{
    public static class TweenExtensions
    {
        public static TweenerCore<T1, T2, T3> UseSettings<T1, T2, T3>(this TweenerCore<T1, T2, T3> tween,
            TweenSettings settings)
            where T3 : struct, IPlugOptions
        {
            if (tween is not { active: true }) return tween;

            return tween
                .SetRelative(settings.Relative)
                .SetSpeedBased(settings.SpeedBased)
                .SetDelay(settings.Delay)
                .SetEase(settings.Ease)
                .SetLoops(settings.Loops, settings.LoopType);
        }
        
        public static Tween MoveTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            return transform
                .DOMove(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static Tween RotTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            return transform
                .DORotate(settings.To, settings.Duration)
                .UseSettings(settings);
        }

        public static Tween ScaleTween(this Transform transform,
            FloatTweenSettings settings)
        {
            return transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static Tween ScaleTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            return transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static Tween FadeTween(this Image image,
            FloatTweenSettings settings)
        {
            return image
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static Tween FadeTween(this CanvasGroup cg,
            FloatTweenSettings settings)
        {
            return cg
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
        }
    }
}