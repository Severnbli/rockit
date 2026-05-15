using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public class TweenPipelineRunObserverPool<T> : BasePool<T> where T : ITweenPipelineRunObserver, new ()
    {
        protected override void PostDespawn(T instance)
        {
            base.PostDespawn(instance);
            
            instance.Reset();
        }
    }
}