using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Player.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Player
{
    public sealed class PlayerGameSceneModule : BaseModule<PlayerGameSceneModule>
    {
        public PlayerGameSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            
            BindSystem<SendPlayerTriggeredVoidOnTriggerEnterEventSystem>();
            BindSystem<SendPlacePlayerRequestOnPlacePlayerToLastCheckpointRequestSystem>();
            BindSystem<SendEnablePlayerRequestOnLevelSpawnedRequestSystem>();
        }
    }
}