using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class GameSceneDomain : SceneDomain
    {
        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<PlatformsMovingModule>();
            TryRegisterModule<PlatformsSharedModule>();
        }
    }
}