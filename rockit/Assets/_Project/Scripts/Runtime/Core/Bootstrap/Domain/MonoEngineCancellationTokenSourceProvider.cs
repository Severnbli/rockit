using System.Threading;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class MonoEngineCancellationTokenSourceProvider : IDomainCancellationTokenSourceProvider
    {
        public CancellationTokenSource GetCancellationTokenSource()
        {
            return null;
        }
    }
}