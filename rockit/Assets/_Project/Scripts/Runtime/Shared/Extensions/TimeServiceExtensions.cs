using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class TimeServiceExtensions
    {
        public static async UniTask<float> GetUniTaskSpentTime(this TimeService timeService, Func<UniTask> func)
        {
            var startTime = timeService.UnscaledTime;
            await func();
            return timeService.UnscaledTime - startTime;
        }
    }
}