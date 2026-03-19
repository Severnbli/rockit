using System.Collections.Generic;
using Leopotam.EcsProto;
using Zenject;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public class SystemsBindResolver
    {
        [Inject(Id = Contracts.NonPausableSystemsId)] private List<IProtoSystem> _nonPausableSystems;
        [Inject(Id = Contracts.PausableSystemsId)] private List<IProtoSystem> _pausableSystems;

        [Inject]
        private void Construct(EcsSystems systems, PausableSystemsSolver solver)
        {
            
        }
    }
}