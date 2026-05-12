using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Effects;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure;
using _Project.Scripts.Runtime.Core.Bootstrap.States;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Project;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Monos;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Systems;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Project
{
    public class ProjectDomain : BaseDomain
    {
        [SerializeField] private AudioSourceContainer _asContainer;
        
        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.BindInstance(_asContainer).AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<PausableSystemsSolver>().ToSelf().AsSingle();
            Container.BindInterfacesTo<DiContainerDomainObjectInstantiator>().AsSingle();
            Container.BindInterfacesTo<ObjectDomain>().AsSingle();
        }

        protected override void RegisterStates()
        {
            base.RegisterStates();
            
            RegisterState<ProjectSetupState>();
            RegisterState<ProjectCloseState>();
            RegisterState<SwitchSceneState>();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<TimeModule>();
            TryRegisterModule<StorageModule>();
            TryRegisterModule<LocalizationModule>();
            TryRegisterModule<ScenesModule>();
            TryRegisterModule<InputModule>();
            TryRegisterModule<GlitchEffectsModule>();
            TryRegisterModule<PlayerStatsModule>();
            TryRegisterModule<AudioModule>();
            TryRegisterModule<LevelsProjectModule>();
            TryRegisterModule<UIProjectModule>();
            TryRegisterModule<RequestsModule>();
        }
    }
}