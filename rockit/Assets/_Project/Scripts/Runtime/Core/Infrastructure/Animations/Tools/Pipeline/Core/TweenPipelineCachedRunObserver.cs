using DG.Tweening;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public class TweenPipelineCachedRunObserver : TweenPipelineRunObserver
    {
        protected override void DoCancel()
        {
            Sequence?.Complete();
        }
    }
}