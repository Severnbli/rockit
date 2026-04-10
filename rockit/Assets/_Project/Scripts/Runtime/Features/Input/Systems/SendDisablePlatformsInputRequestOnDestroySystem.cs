using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public class SendDisablePlatformsInputRequestOnDestroySystem : IProtoDestroySystem
    {
        [DIRequests] private readonly RequestsAspect _aspect;
        
        public void Destroy()
        {
            PlatformsInputUtils.CreateDisableRequest(_aspect);
        }
    }
}