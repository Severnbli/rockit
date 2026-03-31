using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Shared.Utils
{
    public static class UniTaskUtils
    {
        public static async UniTask WaitForRemainingTime(float spentTime, float requiredTime, CancellationToken ct = default)
        {
            var remainingTime = requiredTime - spentTime;
            if (remainingTime <= 0f) return;
            await UniTask.WaitForSeconds(remainingTime, cancellationToken: ct);
        }
    }
}