namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class DataProvider : BaseDataProvider
    {
        public DataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage) : base(keyProvider, dataStorage)
        {
        }
    }
}