using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class SendEnablePlatformsInputRequestOnInitSystem : IProtoInitSystem
    {
        [DI] private readonly DomainAspect _domainAspect;
        
        public void Init(IProtoSystems systems)
        {
            
        }
    }
}