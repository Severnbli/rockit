using System;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataProvider : IDataProvider
    {
        private readonly IDataStorageKeyProvider _keyProvider;
        private readonly IDataStorage _dataStorage;

        public BaseDataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage)
        {
            _keyProvider = keyProvider;
            _dataStorage = dataStorage;
        }

        public T Load<T>()  where T : new()
        {
            var key = _keyProvider.GetKey<T>();
            var data = _dataStorage.GetData(key);

            var item = default(T);
            
            try
            {
                item = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.Log($"Cannot load data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
#endif
                
                item ??= new T();
            }
            
            return item;
        }

        public void Save<T>(T item)
        {
            var key = _keyProvider.GetKey<T>();
            
            try
            {
                var data = JsonConvert.SerializeObject(item);
                _dataStorage.PutData(key, data);
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.Log($"Cannot save data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
#endif
            }
        }
    }
}