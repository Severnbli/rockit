namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public interface IDataProvider
    {
        T Load<T>() where T : new();
        void Save<T>(T item);
        void LoadTracked();
        void SaveTracked();
    }
}