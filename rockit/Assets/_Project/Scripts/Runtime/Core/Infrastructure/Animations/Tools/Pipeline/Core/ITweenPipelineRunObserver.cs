using DG.Tweening;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public interface ITweenPipelineRunObserver
    {
        bool Canceled { get; }
        void Initialize(Sequence sequence);
        void CancelRun();
        void Reset();
    }
}