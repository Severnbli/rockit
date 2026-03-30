using System.Threading;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public interface IDomainCancellationTokenProvider
    {
        CancellationToken GetCancellationToken();
    }
}