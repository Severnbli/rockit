using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class SharedModule : BaseModule<SharedModule>
    {
        public SharedModule(IDomain domain) : base(domain)
        {
        }
    }
}