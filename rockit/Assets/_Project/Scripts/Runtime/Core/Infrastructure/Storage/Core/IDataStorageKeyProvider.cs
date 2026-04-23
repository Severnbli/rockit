using System;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public interface IDataStorageKeyProvider
    {
        string GetKey<T>();
        string GetKey(Type type);
    }
}