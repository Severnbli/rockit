using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public abstract class BaseDomain : MonoInstaller, IDomain
    {
        private SystemsBindResolver _systemsBindResolver = new();
        
        protected ProtoWorld World { get; private set; }
        protected EcsSystems Systems { get; private set; }
        protected readonly HashSet<Type> ModuleInstallers = new();

        protected virtual ProtoWorld ConstructWorld()
        {
            return new ProtoWorld(new DomainAspect());
        }
        
        protected virtual void SetupWorldAndSystems()
        {
            World = ConstructWorld();
            Systems = new EcsSystems(World);
            
            Systems
                .AddModule(new AutoInjectModule())
                .AddModule(new UnityModule());
        }

        protected virtual void PostSetupWorldAndSystems()
        {
            Systems
                .AddModule(new UnityUguiModule())
                .AddModule(new UnityPhysics2DModule());
        }
        
        public sealed override void InstallBindings()
        {
            SetupWorldAndSystems();
            
            Container.Bind<IDomain>().FromInstance(this).AsSingle();
            Container.Bind<ProtoWorld>().FromInstance(World).AsSingle();
            Container.Bind<EcsSystems>().FromInstance(Systems).AsSingle();
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
            
            RegisterBindings();
            RegisterModules();
            RegisterStates();
            
            PostSetupWorldAndSystems();
        }

        public bool TryRegisterModule<T>() where T : BaseModule<T>
        {
            if (!ModuleInstallers.Add(typeof(T)))
            {
                return false;
            }

            Installer<IDomain, T>.Install(Container, this);
            return true;
        }

        public string GetDescriptor()
        {
            return GetType().Name;
        }

        protected virtual void RegisterBindings() {}
        
        protected virtual void RegisterModules() {}
        
        protected virtual void RegisterStates() {}
    }
}