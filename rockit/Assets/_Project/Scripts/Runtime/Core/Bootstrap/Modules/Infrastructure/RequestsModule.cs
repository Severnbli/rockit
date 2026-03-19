using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class RequestsModule : BaseModule<RequestsModule>
    {
        public RequestsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<DelActivatedRequestsSystem>();
            BindSystem<ActivateRequestsSystem>();
            
            BindSystem<DebugSystem>();
        }
    }
}