using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class PlayerInputServiceExtensions
    {
        public static bool TryResetOnDisabled(this PlayerInputService service)
        {
            if (service.Enabled) return false;
            
            service.WalkTriggered = false;
            service.Walk = 0;
            service.JumpTriggered = false;
            service.DashTriggered = false;
            return true;
        }
    }
}