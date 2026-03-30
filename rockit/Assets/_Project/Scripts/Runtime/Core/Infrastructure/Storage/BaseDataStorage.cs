namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        private readonly IDataStorageKeyProvider _keyProvider;

        public BaseDataStorage(IDataStorageKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
        }

        public T Load<T>()  where T : new()
        {
            return new T();
        }

        public void Save<T>(T item)
        {
            
        }
    }
}