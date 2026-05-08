using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class AnimationsModule : BaseModule<AnimationsModule>
    {
        public AnimationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<ITweenPipelineCacheStorage>().To<TweenPipelineCacheStorage>().AsSingle();
            Container.Bind<ITweenPipelineSequenceCreator>().To<TweenPipelineSequenceCreator>().AsSingle();
            Container.Bind<ITweenPipelineRunner>().To<TweenPipelineRunner>().AsSingle();
        }
    }
}