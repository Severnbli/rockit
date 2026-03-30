namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataStorage
    {
        string GetData(string key);
        void PutData(string key, string data);
    }
}