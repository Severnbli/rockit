namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public class TypeNameDataStorageKeyProvider : IDataStorageKeyProvider
    {
        public string GetKey<T>()
        {
            return typeof(T).Name;
        }
    }
}