using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class RequestsModule : BaseModule<RequestsModule>
    {
        public RequestsModule(IDomain domain) : base(domain)
        {
        }
    }
}