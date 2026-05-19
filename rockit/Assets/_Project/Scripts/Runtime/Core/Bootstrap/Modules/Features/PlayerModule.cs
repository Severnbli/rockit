using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features
{
    public sealed class PlayerModule : BaseModule<PlayerModule>
    {
        public PlayerModule(IDomain domain) : base(domain)
        {
        }
    }
}