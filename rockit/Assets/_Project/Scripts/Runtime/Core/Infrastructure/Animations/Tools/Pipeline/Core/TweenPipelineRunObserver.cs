using DG.Tweening;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public abstract class TweenPipelineRunObserver : ITweenPipelineRunObserver
    {
        protected Sequence Sequence;

        public bool Canceled { get; protected set; }

        public void Initialize(Sequence sequence)
        {
            Sequence = sequence;
        }

        public abstract void CancelRun();

        public void Reset()
        {
            Sequence = null;
            Canceled = false;
        }
    }
}