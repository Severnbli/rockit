using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class DataProvider : BaseDataProvider
    {
        public Language Language;
        public GameSceneData GameSceneData;
        public PlayerStats PlayerStats;
        public EconomyData EconomyData;
        
        public DataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage) : base(keyProvider, dataStorage)
        {
        }

        public override void LoadTracked()
        {
            base.LoadTracked();

            Language = Load<Language>();
            GameSceneData = Load<GameSceneData>();
            PlayerStats = Load<PlayerStats>();
            EconomyData = Load<EconomyData>();
        }

        public override void SaveTracked()
        {
            base.SaveTracked();
            
            Save(Language);
            Save(GameSceneData);
            Save(PlayerStats);
            Save(EconomyData);
        }
    }
}