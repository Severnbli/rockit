namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public interface IDataProvider
    {
        string GetData(string key);
        void PutData(string key, string data);
    }
}