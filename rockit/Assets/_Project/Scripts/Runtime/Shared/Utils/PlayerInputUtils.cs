using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Shared.Utils
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
    }
}