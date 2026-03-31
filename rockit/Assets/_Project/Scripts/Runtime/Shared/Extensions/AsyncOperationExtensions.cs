using UnityEngine;

namespace _Project.Scripts.Runtime.Shared.Extensions
{
    public static class AsyncOperationExtensions
    {
        private const float OperationCompletedProgressValue = 0.9f;

        public static bool Completed(this AsyncOperation operation)
        {
            if (operation is null) return false;
            return operation.progress >= OperationCompletedProgressValue;
        }
    }
}