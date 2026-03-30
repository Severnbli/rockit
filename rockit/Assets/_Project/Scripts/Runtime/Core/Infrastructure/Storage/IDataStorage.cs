namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataStorage
    {
        void Load<T>();
        void Save<T>(T item);
    }
}