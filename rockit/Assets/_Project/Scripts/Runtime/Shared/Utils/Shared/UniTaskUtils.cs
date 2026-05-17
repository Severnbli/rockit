using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class UniTaskUtils
    {
        public static async UniTask WaitForRemainingTime(float spentTime, float requiredTime, CancellationToken ct = default)
        {
            var remainingTime = requiredTime - spentTime;
            if (remainingTime <= 0f) return;
            await UniTask.WaitForSeconds(remainingTime, cancellationToken: ct);
        }

        public static async UniTask WaitWithTimeout(UniTask task, TimeSpan timeSpan, CancellationToken ct = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            
            task = task.AttachExternalCancellation(cts.Token);
            var timeoutTask = UniTask.Delay(timeSpan, cancellationToken: cts.Token);
            
            await UniTask.WhenAny(task, timeoutTask);
            cts.Cancel();
        }
    }
}