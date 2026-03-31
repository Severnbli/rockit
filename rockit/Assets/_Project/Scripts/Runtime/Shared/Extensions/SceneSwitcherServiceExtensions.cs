using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class SceneSwitcherServiceExtensions
    {
        private const float Progress01Progress0100Multiplier = 100f;

        public static void SetProgress(this SceneSwitcherService service, AsyncOperation operation)
        {
            if (operation is null) return;

            service.Progress01 = operation.progress;
            service.Progress0100 = service.Progress01 * Progress01Progress0100Multiplier;
        }

        public static void ResetProgress(this SceneSwitcherService service)
        {
            service.Progress01 = 0;
            service.Progress0100 = 0;
        }
    }
}