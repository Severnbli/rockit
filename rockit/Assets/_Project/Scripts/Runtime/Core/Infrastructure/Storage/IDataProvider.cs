namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataProvider
    {
        T Load<T>() where T : new();
        void Save<T>(T item);
        void AddTracked<T>(T item) where T : new();
        void RemoveTracked<T>();
        void LoadTracked();
        void SaveTracked();
    }
}