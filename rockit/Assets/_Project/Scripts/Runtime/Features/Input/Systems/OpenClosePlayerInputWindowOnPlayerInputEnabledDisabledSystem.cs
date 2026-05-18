using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Features.Input.Monos;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class OpenClosePlayerInputWindowOnPlayerInputEnabledDisabledSystem : IProtoRunSystem
    {
        [DIRequests] private readonly InputRequestsAspect _irAspect;
        private readonly PlayerInputWindow _piWindow;

        public OpenClosePlayerInputWindowOnPlayerInputEnabledDisabledSystem(PlayerInputWindow piWindow)
        {
            _piWindow = piWindow;
        }

        public void Run()
        {
            if (!_irAspect.PlayerInputEnabledRequests.IsEmptySlow()) _piWindow.Open();
            
            if (!_irAspect.PlayerInputDisabledRequests.IsEmptySlow()) _piWindow.Close();
        }
    }
}