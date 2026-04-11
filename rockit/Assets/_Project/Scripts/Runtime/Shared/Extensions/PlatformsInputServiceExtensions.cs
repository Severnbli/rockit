using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PlatformsInputServiceExtensions
    {
        public static bool TryResetOnDisabled(this PlatformsInputService service)
        {
            if (service.Enabled) return false;
            
            service.PositionTriggered = false;
            service.RotationTriggered = false;
            service.ScaleTriggered = false;
            return true;
        }
    }
}