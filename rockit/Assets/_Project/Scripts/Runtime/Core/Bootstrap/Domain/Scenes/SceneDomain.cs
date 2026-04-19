using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public abstract class SceneDomain : BaseDomain
    {
        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<SceneStatesBootstrapper>().ToSelf().AsSingle().NonLazy();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<SharedModule>();
            TryRegisterModule<PhysicsSharedModule>();
            TryRegisterModule<MovingModule>();
        }
    }
}