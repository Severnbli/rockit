using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows
{
    public sealed class GameSceneWindowsModule : BaseModule<GameSceneWindowsModule>
    {
        public GameSceneWindowsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SwitchToPauseStateOnClickedPauseSystem>();
            BindSystem<SwitchToGameStateOnClickedGameSystem>();
        }
    }
}