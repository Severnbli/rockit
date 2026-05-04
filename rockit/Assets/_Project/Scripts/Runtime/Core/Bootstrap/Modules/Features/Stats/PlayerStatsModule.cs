using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats
{
    public sealed class PlayerStatsModule : BaseModule<PlayerStatsModule>
    {
        public PlayerStatsModule(IDomain domain) : base(domain)
        {
        }
    }
}