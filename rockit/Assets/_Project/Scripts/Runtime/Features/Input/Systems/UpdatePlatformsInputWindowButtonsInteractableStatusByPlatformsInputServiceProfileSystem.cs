using _Project.Scripts.Runtime.Features.Input.Monos;
using _Project.Scripts.Runtime.Features.Input.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Input.Systems
{
    public sealed class UpdatePlatformsInputWindowButtonsInteractableStatusByPlatformsInputServiceProfileSystem : IProtoRunSystem
    {
        private readonly PlatformsInputWindow _piWindow;
        private readonly PlatformsInputService _piService;

        public UpdatePlatformsInputWindowButtonsInteractableStatusByPlatformsInputServiceProfileSystem(PlatformsInputWindow piWindow, 
            PlatformsInputService piService)
        {
            _piWindow = piWindow;
            _piService = piService;
        }

        public void Run()
        {
            _piWindow.PositionButton.interactable = !_piService.Profile.PositionDisabled;
            _piWindow.RotationButton.interactable = !_piService.Profile.RotationDisabled;
            _piWindow.ScaleButton.interactable = !_piService.Profile.ScaleDisabled;
        }
    }
}