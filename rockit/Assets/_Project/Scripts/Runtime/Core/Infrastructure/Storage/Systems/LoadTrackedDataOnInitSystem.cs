using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Systems
{
    public sealed class LoadTrackedDataOnInitSystem : IProtoInitSystem
    {
        private readonly IDataProvider _dataProvider;

        public LoadTrackedDataOnInitSystem(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Init(IProtoSystems systems)
        {
            _dataProvider.LoadTracked();
        }
    }
}