using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Teleporters.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Animations
{
    public sealed class TeleportersAnimationsModule : BaseModule<TeleportersAnimationsModule>
    {
        public TeleportersAnimationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendTeleporterActivateTriggerOnTeleporterTriggeredRequestSystem>();
        }
    }
}