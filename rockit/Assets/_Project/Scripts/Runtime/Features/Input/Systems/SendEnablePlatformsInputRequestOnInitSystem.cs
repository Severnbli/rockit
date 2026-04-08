using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class SendEnablePlatformsInputRequestOnInitSystem : IProtoInitSystem
    {
        [DIRequests] private readonly RequestsWorldAspect _aspect;
        
        public void Init(IProtoSystems systems)
        {
            PlatformsInputUtils.CreateEnableRequest(_aspect);
        }
    }
}