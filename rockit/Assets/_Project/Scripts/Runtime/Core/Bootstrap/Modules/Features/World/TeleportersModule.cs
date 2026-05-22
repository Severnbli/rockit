using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Teleporters.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World
{
    public sealed class TeleportersModule : BaseModule<TeleportersModule>
    {
        public TeleportersModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendTeleporterTriggeredRequestOnPlayerTriggerEnterRequestSystem>();
        }
    }
}