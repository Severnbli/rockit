using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Systems;
using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class TimeModule : BaseModuleInstaller<TimeModule>
    {
        public TimeModule(EcsSystems systems, PausableSystemsSolver pausableSystemsSolver) : base(systems,
            pausableSystemsSolver)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            Container.Bind<TimeService>().ToSelf().AsSingle();
        }

        protected override void AddSystems()
        {
            base.AddSystems();
            TryAddSystem<TimeServiceUpdateSystem>();
        }
    }
}