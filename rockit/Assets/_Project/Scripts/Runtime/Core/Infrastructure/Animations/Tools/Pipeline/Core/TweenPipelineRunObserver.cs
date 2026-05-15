namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public abstract class TweenPipelineRunObserver : ITweenPipelineRunObserver
    {
        protected bool _canceled;
        
        public bool Canceled() => _canceled;
        
        public abstract void CancelRun();
    }
}