using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Shared.Utils;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class SendDisablePlayerInputRequestOnDestroySystem : IProtoDestroySystem
    {
        [DI] private readonly DomainAspect _domainAspect;
        
        public void Destroy()
        {
            InputUtils.CreateDisablePlayerInputRequest(_domainAspect);
        }
    }
}