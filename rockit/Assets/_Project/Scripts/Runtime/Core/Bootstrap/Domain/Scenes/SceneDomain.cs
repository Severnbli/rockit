using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public class SceneDomain : BaseDomain
    {
        protected override ProtoWorld ConstructWorld()
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.Bind<SceneStatesBootstrapper>().ToSelf().AsSingle().NonLazy();
        }
    }
}