using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class ScenesModule : BaseModule<ScenesModule>
    {
        public ScenesModule(IDomain domain) : base(domain)
        {
        }
    }
}