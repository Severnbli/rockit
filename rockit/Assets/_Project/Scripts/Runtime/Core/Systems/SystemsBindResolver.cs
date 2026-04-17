using System.Linq;
using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity;
using Leopotam.EcsProto.Unity.Physics2D;
using Leopotam.EcsProto.Unity.Ugui;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class SystemsBindResolver : IInitializable
    {
        private readonly DiContainer _container;
        private readonly IDomain _domain;
        
        private EcsSystems _systems;
        private PausableSystemsSolver _solver;
        private IProtoSystem[] _nonPausableSystems;
        private IProtoSystem[] _pausableSystems;
        private ProtoWorld _requestsWorld;

        public SystemsBindResolver(DiContainer container, IDomain domain)
        {
            _container = container;
            _domain = domain;
        }

        public void Initialize()
        {
            _systems = _container.Resolve<EcsSystems>();
            _solver = _container.Resolve<PausableSystemsSolver>();
            _nonPausableSystems =
                _container.ResolveId<IProtoSystem[]>(_domain.GetDescriptor(SystemsContracts.NonPausableSystemsId));
            _pausableSystems =
                _container.ResolveId<IProtoSystem[]>(_domain.GetDescriptor(SystemsContracts.PausableSystemsId));
            
            ResolveSystems();
            ResolveRequestsWorld();
            ResolvePredefinedModules();
        }

        private void ResolveSystems()
        {
            _systems.AddModule(new AutoInjectModule());
            
            foreach (var system in _nonPausableSystems)
            {
                _systems.AddSystem(system);
            }
            
            if (_pausableSystems.Any())
            {
                _systems.AddSystem(new PausableSystems(_solver, _pausableSystems));
            }
        }

        private void ResolveRequestsWorld()
        {
            _requestsWorld = _container.Resolve<RequestsWorldProvider>().GetWorld();
            _systems.AddWorld(_requestsWorld, RequestsContracts.RequestsIdentifier);
        }

        private void ResolvePredefinedModules()
        {
            _systems
                .AddModule(new UnityModule())
                .AddModule(new UnityUguiModule())
                .AddModule(new UnityPhysics2DModule());
        }
    }
}