using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Checkpoints;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;
using _Project.Scripts.Runtime.Features.Graphics.Particles.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class GameSceneDomain : SceneDomain
    {
        [SerializeField] private LevelsContainer _lContainer;
        [SerializeField] private ParticleSystemsContainer _psContainer;
        [SerializeField] private GameWindow _gWindow;
        [SerializeField] private VoidWindow _vWindow;
        [SerializeField] private PauseWindow _pWindow;

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInstance(_lContainer).AsSingle();
            Container.BindInstance(_psContainer).AsSingle();
            Container.BindInstance(_gWindow).AsSingle();
            Container.BindInstance(_vWindow).AsSingle();
            Container.BindInstance(_pWindow).AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<GameSceneSetupState>();
            RegisterState<SpawnLevelState>();
            RegisterState<GameState>();
            RegisterState<VoidState>();
            RegisterState<PauseState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<PlatformsMovingModule>();
            TryRegisterModule<PlatformsSharedModule>();
            TryRegisterModule<PlatformsGraphicsModule>();
            TryRegisterModule<LevelsSceneModule>();
            TryRegisterModule<ParticlesModule>();
            TryRegisterModule<CheckpointsSceneModule>();
            TryRegisterModule<VoidModule>();
            TryRegisterModule<GameSceneWindowsModule>();
        }
    }
}