using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class SendEnablePlatformsInputRequestOnInitSystem : IProtoInitSystem
    {
        [DIRequests] private readonly DomainAspect _domainAspect;
        
        public void Init(IProtoSystems systems)
        {
            PlatformsInputUtils.CreateEnableRequest(_domainAspect);
        }
    }
}