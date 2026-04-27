using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Systems
{
    public sealed class SaveTrackedDataOnSaveTrackedDataRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly StorageRequestsAspect _srAspect;
        private readonly IDataProvider _dProvider;

        public SaveTrackedDataOnSaveTrackedDataRequestSystem(IDataProvider dProvider)
        {
            _dProvider = dProvider;
        }

        public void Run()
        {
            if (_srAspect.SaveTrackedDataRequests.IsEmptySlow()) return;
            
            _dProvider.SaveTracked();
        }
    }
}