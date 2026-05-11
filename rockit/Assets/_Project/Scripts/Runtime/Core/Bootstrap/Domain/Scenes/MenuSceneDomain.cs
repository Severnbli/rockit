using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        [SerializeField] private MenuWindow _mWindow;
        [SerializeField] private LevelSelectionWindow _lsWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInstance(_mWindow).AsSingle();
            Container.BindInstance(_lsWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
            RegisterState<MenuState>();
            RegisterState<LevelSelectionState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<MenuSceneWindowsModule>();
        }
    }
}