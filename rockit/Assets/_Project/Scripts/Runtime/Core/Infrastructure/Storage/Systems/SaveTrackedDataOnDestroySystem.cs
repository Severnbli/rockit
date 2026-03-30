using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Systems
{
    public sealed class SaveTrackedDataOnDestroySystem : IProtoDestroySystem
    {
        private readonly IDataProvider _dataProvider;

        public SaveTrackedDataOnDestroySystem(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Destroy()
        {
            _dataProvider.SaveTracked();
        }
    }
}