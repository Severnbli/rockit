using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Core;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Economy;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Scenes.Game;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities.Stats;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage
{
    public class DataProvider : BaseDataProvider
    {
        public LanguageData LanguageData;
        public GameSceneData GameSceneData;
        public PlayerStatsData PlayerStatsData;
        public EconomyData EconomyData;
        
        public DataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage) : base(keyProvider, dataStorage)
        {
        }

        public override void LoadTracked()
        {
            base.LoadTracked();

            LanguageData = Load<LanguageData>();
            GameSceneData = Load<GameSceneData>();
            PlayerStatsData = Load<PlayerStatsData>();
            EconomyData = Load<EconomyData>();
        }

        public override void SaveTracked()
        {
            base.SaveTracked();
            
            Save(LanguageData);
            Save(GameSceneData);
            Save(PlayerStatsData);
            Save(EconomyData);
        }
    }
}