using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class SharedModule : BaseModule<SharedModule>
    {
        public SharedModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<SharedIndexService>();
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendInitializeRequestsOnRunSystem>();
        }
    }
}