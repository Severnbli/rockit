using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

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
                .SetEase(settings.Easing)
                .SetLoops(settings.Loops, settings.LoopType);
        }
    }
}