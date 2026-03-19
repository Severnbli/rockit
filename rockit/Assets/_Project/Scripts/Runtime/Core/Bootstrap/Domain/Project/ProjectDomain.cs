using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure;
using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Project
{
    public class ProjectDomain : BaseDomain
    {
        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<PausableSystemsSolver>().ToSelf().AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            Container.BindInterfacesAndSelfTo<ProjectSetupState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectCloseState>().AsSingle();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<TimeModule>();
        }
    }
}