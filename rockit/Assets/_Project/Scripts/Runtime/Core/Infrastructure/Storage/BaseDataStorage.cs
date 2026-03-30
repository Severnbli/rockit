using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

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

        public void Load<T>()
        {
            
        }

        public void Save<T>(T item)
        {
            
        }
    }
}