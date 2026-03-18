using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Systems;
using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class TimeModule : BaseModule<TimeModule>
    {
        public TimeModule(EcsSystems systems) : base(systems)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<TimeService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<TimeServiceUpdateSystem>();
        }
    }
}