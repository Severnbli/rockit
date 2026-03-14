using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Core.Bootstrap.Features;
using _Project.Scripts.Runtime.Core.Engine;
using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public abstract class BaseDomain : MonoInstaller, IDomain
    {
        protected readonly ProtoWorld World;
        protected readonly EcsSystems Systems;
        protected readonly HashSet<Type> FeatureInstallers = new();

        public BaseDomain(ProtoWorld world)
        {
            World = world;
            Systems = new EcsSystems(world);
        }
        
        public sealed override void InstallBindings()
        {
            Container.Bind<ProtoWorld>().FromInstance(World).AsSingle();
            Container.Bind<EcsSystems>().FromInstance(Systems).AsSingle();
            Container.Bind<MonoEngine>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
            
            InstallFeatures();
        }

        public bool TryInstallFeature<T>() where T : BaseFeatureInstaller<T>
        {
            if (!FeatureInstallers.Add(typeof(T)))
            {
                return false;
            }

            Installer<T>.Install(Container);
            return true;
        }
        
        protected virtual void InstallFeatures() {}
    }
}