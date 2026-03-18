using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public abstract class BaseDomain : MonoInstaller, IDomain
    {
        protected ProtoWorld World { get; private set; }
        protected EcsSystems Systems { get; private set; }
        protected readonly HashSet<Type> ModuleInstallers = new();
        
        protected abstract ProtoWorld ConstructWorld();
        
        private void SetupWorldAndSystems()
        {
            World = ConstructWorld();
            Systems = new EcsSystems(World);
        }
        
        public sealed override void InstallBindings()
        {
            SetupWorldAndSystems();
            
            Container.Bind<ProtoWorld>().FromInstance(World).AsSingle();
            Container.Bind<EcsSystems>().FromInstance(Systems).AsSingle();
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
            
            RegisterBindings();
            RegisterModules();
            RegisterStates();
        }

        public bool TryInstallModule<T>() where T : BaseModuleInstaller<T>
        {
            if (!ModuleInstallers.Add(typeof(T)))
            {
                return false;
            }

            Installer<T>.Install(Container);
            return true;
        }
        
        protected virtual void RegisterBindings() {}
        
        protected virtual void RegisterModules() {}
        
        protected virtual void RegisterStates() {}
    }
}