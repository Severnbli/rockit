using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Monos;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class OpenClosePlatformsInputWindowOnPlatformsInputEnabledDisabledSystem : IProtoRunSystem
    {
        [DIRequests] private readonly InputRequestsAspect _irAspect;
        private readonly PlayerInputWindow _piWindow;

        public OpenClosePlatformsInputWindowOnPlatformsInputEnabledDisabledSystem(PlayerInputWindow piWindow)
        {
            _piWindow = piWindow;
        }

        public void Run()
        {
            if (!_irAspect.PlatformsInputEnabledRequests.IsEmptySlow()) _piWindow.Open();
            
            if (!_irAspect.PlatformsInputDisabledRequests.IsEmptySlow()) _piWindow.Close();
        }
    }
}