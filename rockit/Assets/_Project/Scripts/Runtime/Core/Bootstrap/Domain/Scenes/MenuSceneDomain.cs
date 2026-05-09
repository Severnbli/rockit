using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
        }
    }
}