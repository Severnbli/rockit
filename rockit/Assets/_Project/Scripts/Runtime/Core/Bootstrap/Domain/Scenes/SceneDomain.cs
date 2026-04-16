using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Moving;
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

            TryRegisterModule<MovingModule>();
        }
    }
}