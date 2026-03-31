using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class SceneSwitcherServiceExtensions
    {
        private const float Progress01Progress0100Multiplier = 100f;
        private const float DefaultProgress = 0f;
        private const float Progress01MaxValue = 1f;
        private const float Progress0100MaxValue = 100f;

        public static void SetProgress(this SceneSwitcherService service, AsyncOperation operation)
        {
            if (operation is null) return;

            service.Progress01 = operation.progress;
            service.Progress0100 = service.Progress01 * Progress01Progress0100Multiplier;
        }

        public static void ResetProgress(this SceneSwitcherService service)
        {
            service.Progress01 = DefaultProgress;
            service.Progress0100 = DefaultProgress;
        }

        public static void SetMaxProgress(this SceneSwitcherService service)
        {
            service.Progress01 = Progress01MaxValue;
            service.Progress0100 = Progress0100MaxValue;
        }

        public static void Reset(this SceneSwitcherService service)
        {
            service.ResetProgress();
            service.Loaded = false;
        }
    }
}