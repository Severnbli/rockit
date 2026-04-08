using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class SendEnablePlayerInputRequestOnInitSystem : IProtoInitSystem
    {
        [DI] private DomainAspect _domainAspect;
        
        public void Init(IProtoSystems systems)
        {
            InputUtils.CreateEnablePlayerInputRequest(_domainAspect);
        }
    }
}