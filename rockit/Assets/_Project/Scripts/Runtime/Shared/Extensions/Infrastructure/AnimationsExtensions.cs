using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Types;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Shared.Extensions.Infrastructure
{
    public static class AnimationsExtensions
    {
        public static TweenerCore<T1, T2, T3> UseSettings<T1, T2, T3, T4>(this TweenerCore<T1, T2, T3> tween,
            TweenSettings<T4> settings)
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
            var tween = transform
                .DOMove(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }
        
        public static Tween RotTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            var tween = transform
                .DORotate(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }

        public static Tween ScaleTween(this Transform transform,
            FloatTweenSettings settings)
        {
            var tween = transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }
        
        public static Tween ScaleTween(this Transform transform,
            Vector3TweenSettings settings)
        {
            var tween = transform
                .DOScale(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }
        
        public static Tween FadeTween(this Image image,
            FloatTweenSettings settings)
        {
            var tween = image
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }
        
        public static Tween FadeTween(this CanvasGroup cg,
            FloatTweenSettings settings)
        {
            var tween = cg
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }
        
        public static Tween FadeTween(this AudioSource aSource,
            FloatTweenSettings settings)
        {
            var tween = aSource
                .DOFade(settings.To, settings.Duration)
                .UseSettings(settings);
            if (settings.FromExact) tween.From(settings.From);
            
            return tween;
        }

        public static T LinkToCancellationToken<T>(this T tween, CancellationToken ct) where T : Tween
        {
            if (tween is not { active: true }) return tween;

            if (ct.IsCancellationRequested)
            {
                tween.Kill();
                return tween;
            }
            
            var registration = ct.Register(() => tween.Kill());
            tween.OnKill(registration.Dispose);
            
            return tween;
        }
    }
}