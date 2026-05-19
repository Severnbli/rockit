using _Project.Scripts.Runtime.Features.Input.Types;

namespace _Project.Scripts.Runtime.Features.Input.Services
{
    public sealed class PlatformsInputService
    {
        public bool Enabled;
        public bool PositionTriggered;
        public bool RotationTriggered;
        public bool ScaleTriggered;
        public PlatformsInputProfile Profile = default;
    }
}