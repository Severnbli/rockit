using _Project.Scripts.Runtime.Features.Input.Services;
using UnityEngine;

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

        public static void SetWalkFieldsByVector2(this PlayerInputService service, Vector2 input)
        {
            if (Mathf.Approximately(input.x, 0f))
            {
                service.WalkTriggered = false;
                service.Walk = 0;
                return;
            }
            
            service.WalkTriggered = true;
            service.Walk = input.x;
        }
    }
}