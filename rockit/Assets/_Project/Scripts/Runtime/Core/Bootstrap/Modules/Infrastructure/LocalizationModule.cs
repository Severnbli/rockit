using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class LocalizationModule : BaseModule<LocalizationModule>
    {
        public LocalizationModule(IDomain domain) : base(domain)
        {
        }
    }
}