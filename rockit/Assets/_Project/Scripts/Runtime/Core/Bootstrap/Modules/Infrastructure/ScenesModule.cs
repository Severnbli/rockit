using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class ScenesModule : BaseModule<ScenesModule>
    {
        public ScenesModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<SceneSwitcherService>();
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.BindInterfacesTo<SceneSwitcher>().AsSingle();
        }
    }
}