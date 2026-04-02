using System;
using _Project.Scripts.Runtime.Shared.Utils;
using Newtonsoft.Json;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public class BaseDataProvider : IDataProvider
    {
        protected readonly IDataStorageKeyProvider KeyProvider;
        protected readonly IDataStorage DataStorage;

        public BaseDataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage)
        {
            KeyProvider = keyProvider;
            DataStorage = dataStorage;
        }

        public T Load<T>()  where T : new()
        {
            var key = KeyProvider.GetKey<T>();
            var data = DataStorage.GetData(key);

            var item = default(T);
            
            try
            {
                item = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                LogUtils.LogWarning($"Cannot load data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
                
                item ??= new T();
            }
            
            return item;
        }

        public void Save<T>(T item)
        {
            var key = KeyProvider.GetKey<T>();
            
            try
            {
                var data = JsonConvert.SerializeObject(item);
                DataStorage.PutData(key, data);
            }
            catch (Exception e)
            {
                LogUtils.LogWarning($"Cannot save data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
            }
        }

        public virtual void LoadTracked()
        {
            
        }

        public virtual void SaveTracked()
        {
            
        }
    }
}