using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Defined.Menu;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        [SerializeField] private MonoMenuWindow _menuWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<MonoMenuWindow>().FromInstance(_menuWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
        }
    }
}