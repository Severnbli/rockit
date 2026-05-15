namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public abstract class TweenPipelineRunObserver : ITweenPipelineRunObserver
    {
        public bool Canceled { get; protected set; }
        
        public abstract void CancelRun();
    }
}