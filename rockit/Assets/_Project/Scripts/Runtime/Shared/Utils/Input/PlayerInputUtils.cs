using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Shared.Utils.Input
{
    public static class PlayerInputUtils
    {
        public static void EnableInput(PlayerInputService service, PlayerInputConfig config)
        {
            service.Enabled = true;
            config.Walk.Enable();
            config.Jump.Enable();
            config.Dash.Enable();
        }

        public static void DisableInput(PlayerInputService service, PlayerInputConfig config)
        {
            service.Enabled = false;
            config.Walk.Disable();
            config.Jump.Disable();
            config.Dash.Disable();
        }
    }
}