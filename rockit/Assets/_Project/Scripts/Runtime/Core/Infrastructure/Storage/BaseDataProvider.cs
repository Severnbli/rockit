using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class BaseDataProvider : IDataProvider
    {
        protected readonly IDataStorageKeyProvider KeyProvider;
        protected readonly IDataStorage DataStorage;
        protected readonly Dictionary<Type, object> TrackedData = new ();

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
#if DEBUG
                Debug.Log($"Cannot load data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
#endif
                
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
#if DEBUG
                Debug.Log($"Cannot save data of type \"{typeof(T).Name}\" with \"{key}\" key: {e.Message}");
#endif
            }
        }

        public void AddTracked<T>(T item) where T : new()
        {
            
        }

        public void RemoveTracked<T>()
        {
            
        }

        public void LoadTracked()
        {
            
        }

        public void SaveTracked()
        {
            
        }
    }
}