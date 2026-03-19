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
            
        }
    }
}