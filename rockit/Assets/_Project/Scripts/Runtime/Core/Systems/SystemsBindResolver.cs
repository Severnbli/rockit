using System.Linq;
using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class SystemsBindResolver : IInitializable
    {
        private readonly DiContainer _container;
        private readonly IDomain _domain;

        public SystemsBindResolver(DiContainer container, IDomain domain)
        {
            _container = container;
            _domain = domain;
        }

        public void Initialize()
        {
            var systems = _container.Resolve<EcsSystems>();
            var solver = _container.Resolve<PausableSystemsSolver>();
            var nonPausableSystems =
                _container.ResolveId<IProtoSystem[]>(_domain.GetDescriptor(SystemsContracts.NonPausableSystemsId));
            var pausableSystems =
                _container.ResolveId<IProtoSystem[]>(_domain.GetDescriptor(SystemsContracts.PausableSystemsId));
            
            foreach (var system in nonPausableSystems)
            {
                systems.AddSystem(system);
            }
            
            if (pausableSystems.Any())
            {
                systems.AddSystem(new PausableSystems(solver, pausableSystems));
            }

            var requestsWorld = _container.Resolve<RequestsWorldProvider>().GetWorld();
            systems.AddWorld(requestsWorld, RequestsContracts.RequestsIdentifier);
        }
    }
}