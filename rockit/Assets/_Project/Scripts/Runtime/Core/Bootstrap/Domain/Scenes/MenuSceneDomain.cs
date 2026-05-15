using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Active;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Menu.Modal;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Menu.Monos;
using _Project.Scripts.Runtime.Features.Stats.Constants.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class MenuSceneDomain : SceneDomain
    {
        [SerializeField] private MenuWindow _mWindow;
        [SerializeField] private LevelSelectionWindow _lsWindow;
        [SerializeField] private LevelButtonContainer _lbContainer;
        [SerializeField] private ConstantDisplayWindow _cdWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInstance(_mWindow).AsSingle();
            Container.BindInstance(_lsWindow).AsSingle();
            Container.BindInstance(_lbContainer).AsSingle();
            Container.BindInstance(_cdWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<MenuSceneSetupState>();
            RegisterState<CreateLevelButtonsState>();
            RegisterState<MenuState>();
            RegisterState<LevelSelectionState>();
            RegisterState<ConstantDisplayWindowState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<MenuSceneWindowsModule>();
        }
    }
}