namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public interface ITweenPipelineRunObserver
    {
        bool Canceled { get; }
        void CancelRun();
    }
}