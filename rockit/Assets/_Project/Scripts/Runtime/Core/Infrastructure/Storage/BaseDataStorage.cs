namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataStorage : IDataStorage
    {
        private readonly IDataStorageKeyProvider _keyProvider;
        private readonly IDataProvider _dataProvider;

        public BaseDataStorage(IDataStorageKeyProvider keyProvider, IDataProvider dataProvider)
        {
            _keyProvider = keyProvider;
            _dataProvider = dataProvider;
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