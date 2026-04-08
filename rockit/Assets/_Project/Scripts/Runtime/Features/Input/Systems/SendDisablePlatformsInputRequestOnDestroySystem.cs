using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class SendDisablePlatformsInputRequestOnDestroySystem : IProtoDestroySystem
    {
        [DI] private readonly DomainAspect _domainAspect;
        
        public void Destroy()
        {
            PlatformsInputUtils.CreateDisableRequest(_domainAspect);
        }
    }
}