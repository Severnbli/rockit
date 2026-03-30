using System.Threading;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public interface IDomainCancellationTokenSourceProvider
    {
        CancellationTokenSource GetCancellationTokenSource();
    }
}