namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataStorageKeyProvider
    {
        string GetKey<T>();
    }
}