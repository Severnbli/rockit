using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Features;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Systems
{
    public sealed class TranslatePositionPlatformTriggeredRequestIntoAnyPlatformTriggeredRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DIRequests] private readonly PlatformsSharedRequestsAspect _psrAspect;
        
        public void Run()
        {
            if (_psrAspect.AnyPlatformTriggeredRequests.IsEmptySlow()) return;

            PlatformsUtils.CreateAnyPlatformTriggeredRequest(_rAspect);
        }
    }
}