using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes.Game.Active;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class GameSceneDomain : SceneDomain
    {
        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<GameSceneSetupState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<PlatformsMovingModule>();
            TryRegisterModule<PlatformsSharedModule>();
            TryRegisterModule<PlatformsGraphicsModule>();
            TryRegisterModule<LevelsSceneModule>();
        }
    }
}