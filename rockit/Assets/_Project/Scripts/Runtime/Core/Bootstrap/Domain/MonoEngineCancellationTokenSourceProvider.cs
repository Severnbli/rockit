using System.Threading;
using _Project.Scripts.Runtime.Core.Engine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class MonoEngineCancellationTokenSourceProvider : IDomainCancellationTokenSourceProvider
    {
        private MonoEngine _monoEngine;

        public MonoEngineCancellationTokenSourceProvider(MonoEngine monoEngine)
        {
            _monoEngine = monoEngine;
        }

        public CancellationTokenSource GetCancellationTokenSource()
        {
            return null;
        }
    }
}