using DG.Tweening;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tweens.Pipeline.Core
{
    public interface ITweenPipelineAnimatable
    {
        Sequence Animate(TweenPipeline tp);
    }
}