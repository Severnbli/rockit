using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Systems
{
    public sealed class LoadTrackedDataOnLoadTrackedRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly StorageRequestsAspect _srAspect;
        private readonly IDataProvider _dProvider;

        public LoadTrackedDataOnLoadTrackedRequestSystem(IDataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_srAspect.LoadTrackedDataRequests.IsEmptySlow()) return;
            
            _dProvider.LoadTracked();
        }
    }
}