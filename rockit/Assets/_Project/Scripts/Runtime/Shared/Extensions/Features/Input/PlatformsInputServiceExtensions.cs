using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Input.Types;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Input
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

        public static void SetProfile(this PlatformsInputService service, PlatformsInputProfile profile)
        {
            service.Profile = profile;
        }
    }
}