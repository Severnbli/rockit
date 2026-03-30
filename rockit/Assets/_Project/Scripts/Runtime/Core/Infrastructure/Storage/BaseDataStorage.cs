namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        private readonly IDataStorageKeyProvider _keyProvider;

        public BaseDataStorage(IDataStorageKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
        }

        public void Load<T>()
        {
            
        }

        public void Save<T>(T item)
        {
            
        }
    }
}