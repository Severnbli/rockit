using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;
using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class GameSceneDomain : SceneDomain
    {
        [SerializeField] private LevelsContainer _lContainer;
        
        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            Container.BindInstance(_lContainer).AsSingle();
            RegisterState<GameSceneSetupState>();
            RegisterState<SpawnLevelState>();
            RegisterState<GameState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<PlatformsMovingModule>();
            TryRegisterModule<PlatformsSharedModule>();
            TryRegisterModule<PlatformsGraphicsModule>();
            TryRegisterModule<LevelsSceneModule>();
            TryRegisterModule<ParticlesModule>();
        }
    }
}