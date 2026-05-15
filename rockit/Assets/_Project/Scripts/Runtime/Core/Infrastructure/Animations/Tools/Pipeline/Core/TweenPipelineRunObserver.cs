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

        public void CancelRun()
        {
            if (Canceled) return;
            DoCancel();
            Canceled = true;
        }

        protected abstract void DoCancel();

        public void Reset()
        {
            Sequence = null;
            Canceled = false;
        }
    }
}