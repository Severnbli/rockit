using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos.Defined.Menu;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        [SerializeField] private MenuWindow _menuWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInstance(_menuWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
            RegisterState<MenuWindowState>();
        }
    }
}