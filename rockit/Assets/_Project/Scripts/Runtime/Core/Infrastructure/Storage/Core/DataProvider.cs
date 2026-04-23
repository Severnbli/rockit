using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core
{
    public class DataProvider : BaseDataProvider
    {
        public Language Language;
        
        public DataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage) : base(keyProvider, dataStorage)
        {
        }

        public override void LoadTracked()
        {
            base.LoadTracked();

            Language = Load<Language>();
        }

        public override void SaveTracked()
        {
            base.SaveTracked();
            
            Save(Language);
        }
    }
}