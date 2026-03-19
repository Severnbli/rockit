using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class SystemsBindResolver
    {
        [Inject(Id = Contracts.NonPausableSystemsId)] private IProtoSystem[] _nonPausableSystems;
        [Inject(Id = Contracts.PausableSystemsId)] private IProtoSystem[] _pausableSystems;

        [Inject]
        private void Construct(EcsSystems systems, PausableSystemsSolver solver)
        {
            foreach (var system in _nonPausableSystems)
            {
                systems.AddSystem(system);
            }
            
            systems.AddSystem(new PausableSystems(solver, _pausableSystems));
        }
    }
}