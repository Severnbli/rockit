using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.World
{
    public class RequestsWorldDestroyer : IDisposable
    {
        private readonly RequestsWorldProvider _worldProvider;

        public RequestsWorldDestroyer(RequestsWorldProvider worldProvider)
        {
            _worldProvider = worldProvider;
        }

        public void Dispose()
        {
            _worldProvider.GetWorld()?.Destroy();
        }
    }
}