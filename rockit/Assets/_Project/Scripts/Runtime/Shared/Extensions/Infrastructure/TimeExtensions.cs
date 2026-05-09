using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Shared.Extensions.Infrastructure
{
    public static class TimeExtensions
    {
        public static async UniTask<float> GetUniTaskSpentTime(this TimeService timeService, Func<UniTask> func)
        {
            var startTime = timeService.UnscaledTime;
            await func();
            return timeService.UnscaledTime - startTime;
        }

        public static bool Expired(this TimeService timeService, float creationTime, float timeout)
        {
            return timeService.UnscaledTime > creationTime + timeout;
        }
    }
}