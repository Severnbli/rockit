using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats
{
    public sealed class StatsSharedModule : BaseModule<StatsSharedModule>
    {
        public StatsSharedModule(IDomain domain) : base(domain)
        {
        }
    }
}