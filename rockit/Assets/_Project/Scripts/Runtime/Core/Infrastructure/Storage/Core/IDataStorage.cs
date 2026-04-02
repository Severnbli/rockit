namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public interface IDataStorage
    {
        string GetData(string key);
        void PutData(string key, string data);
    }
}