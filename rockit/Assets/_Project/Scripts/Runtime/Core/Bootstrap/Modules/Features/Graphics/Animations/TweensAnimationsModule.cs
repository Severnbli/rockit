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

            Container.BindInterfacesAndSelfTo<TweenPipelineCacheStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<TweenPipelineRunner>().AsSingle();
        }
    }
}