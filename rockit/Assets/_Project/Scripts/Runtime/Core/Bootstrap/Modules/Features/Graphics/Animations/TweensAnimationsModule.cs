using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Animations
{
    public sealed class TweensAnimationsModule : BaseModule<TweensAnimationsModule>
    {
        public TweensAnimationsModule(IDomain domain) : base(domain)
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