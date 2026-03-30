using Newtonsoft.Json;

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
            var key = _keyProvider.GetKey<T>();
            var data = _dataProvider.GetData(key);
            
            var item = JsonConvert.DeserializeObject<T>(data);
            item ??= new T();
            
            return item;
        }

        public void Save<T>(T item)
        {
            
        }
    }
}