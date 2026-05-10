using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Defined.Menu;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        [SerializeField] private MenuWindow _menuWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<MenuWindow>().FromInstance(_menuWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
        }
    }
}