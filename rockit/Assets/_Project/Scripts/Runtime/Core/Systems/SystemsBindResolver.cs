using System.Linq;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class SystemsBindResolver : IInitializable
    {
        private DiContainer _container;

        public SystemsBindResolver(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            var systems = _container.Resolve<EcsSystems>();
            var solver = _container.Resolve<PausableSystemsSolver>();
            var nonPausableSystems = _container.ResolveId<IProtoSystem[]>(Contracts.NonPausableSystemsId);
            var pausableSystems = _container.ResolveId<IProtoSystem[]>(Contracts.PausableSystemsId);
            
            foreach (var system in nonPausableSystems)
            {
                systems.AddSystem(system);
            }
            
            if (pausableSystems.Any())
            {
                systems.AddSystem(new PausableSystems(solver, pausableSystems));
            }
        }
    }
}