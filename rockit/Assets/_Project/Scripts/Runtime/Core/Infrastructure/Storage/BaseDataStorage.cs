using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        private readonly IDataStorageKeyProvider _keyProvider;
        private readonly CancellationToken _ct;

        public BaseDataStorage(IDataStorageKeyProvider keyProvider, CancellationToken ct)
        {
            _keyProvider = keyProvider;
            _ct = ct;
        }

        public async UniTask Load<T>()
        {
            
        }

        public async UniTask Save<T>(T item)
        {
            
        }
    }
}