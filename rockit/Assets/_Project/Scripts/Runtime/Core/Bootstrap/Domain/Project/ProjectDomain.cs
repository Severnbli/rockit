using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Project
{
    public class ProjectDomain : BaseDomain
    {
        public ProjectDomain(ProtoWorld world) : base(world)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            Container.BindInterfacesAndSelfTo<ProjectSetupState>().AsSingle();
        }
    }
}