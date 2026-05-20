using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Player.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features
{
    public sealed class PlayerModule : BaseModule<PlayerModule>
    {
        public PlayerModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<PlacePlayerOnPlacePlayerRequestSystem>();
            BindSystem<SendPlayerTriggeredVoidOnTriggerEnterEventSystem>();
            BindSystem<SendPlacePlayerRequestOnPlacePlayerToLastCheckpointRequestSystem>();
        }
    }
}