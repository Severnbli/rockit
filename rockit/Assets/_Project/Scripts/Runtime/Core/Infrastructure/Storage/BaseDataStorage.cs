using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        private readonly IDataStorageKeyProvider _keyProvider;

        public BaseDataStorage(IDataStorageKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
        }

        public async UniTask Load<T>()
        {
            
        }

        public async UniTask Save<T>(T item)
        {
            
        }
    }
}