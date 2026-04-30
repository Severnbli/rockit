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
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> MoveTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            if (transform == null) return null;
            
            return transform
                .DOMove(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> RotTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            if (transform == null) return null;
            
            return transform
                .DORotate(settings.To, settings.Duration)
                .UseSettings(settings);
        }

        public static TweenerCore<Vector3, Vector3, VectorOptions> ScaleTween(this Transform transform,
            FloatTweenSettings settings)
        {
            if (transform == null) return null;
            
            return transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> ScaleTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            if (transform == null) return null;
            
            return transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static TweenerCore<Color, Color, ColorOptions> FadeTween(this Image image,
            FloatTweenSettings settings)
        {
            if (image == null) return null;
            
            return image
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
        }
        
        public static TweenerCore<float, float, FloatOptions> FadeTween(this CanvasGroup cg,
            FloatTweenSettings settings)
        {
            return cg
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
        }
    }
}