using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World
{
    public sealed class TeleportersModule : BaseModule<TeleportersModule>
    {
        public TeleportersModule(IDomain domain) : base(domain)
        {
        }
    }
}