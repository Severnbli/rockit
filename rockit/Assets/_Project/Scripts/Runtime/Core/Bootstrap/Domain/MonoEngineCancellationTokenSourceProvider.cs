using System.Threading;
using _Project.Scripts.Runtime.Core.Engine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain
{
    public class MonoEngineCancellationTokenProvider : IDomainCancellationTokenProvider
    {
        private MonoEngine _monoEngine;

        public MonoEngineCancellationTokenProvider(MonoEngine monoEngine)
        {
            _monoEngine = monoEngine;
        }

        public CancellationToken GetCancellationToken()
        {
            return _monoEngine.destroyCancellationToken;
        }
    }
}