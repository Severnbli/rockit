namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataStorage
    {
        T Load<T>() where T : new();
        void Save<T>(T item);
    }
}