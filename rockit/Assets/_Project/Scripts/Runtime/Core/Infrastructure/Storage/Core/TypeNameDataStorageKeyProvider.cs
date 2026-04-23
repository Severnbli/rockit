using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public class TypeNameDataStorageKeyProvider : IDataStorageKeyProvider
    {
        public string GetKey<T>()
        {
            return GetKey(typeof(T));
        }

        public string GetKey(Type type)
        {
            return type.Name;
        }
    }
}