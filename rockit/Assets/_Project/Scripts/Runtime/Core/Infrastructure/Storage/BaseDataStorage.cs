using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        public async UniTask Load<T>()
        {
            
        }

        public async UniTask Save<T>(T item)
        {
            
        }
    }
}