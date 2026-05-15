using DG.Tweening;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public class TweenPipelineNonCachedRunObserver : TweenPipelineRunObserver
    {
        protected override void DoCancel()
        {
            Sequence?.Kill();
        }
    }
}