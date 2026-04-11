using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PlatformsInputServiceExtensions
    {
        public static bool TryResetOnDisabled(this PlatformsInputService service)
        {
            if (service.Enabled) return false;
            
            service.PositionPerformed = false;
            service.RotationPerformed = false;
            service.ScalePerformed = false;
            return true;
        }
    }
}