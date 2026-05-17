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
        public StatsData StatsData;
        public EconomyData EconomyData;
        public AudioData AudioData;
        
        public DataProvider(IDataStorageKeyProvider keyProvider, IDataStorage dataStorage) : base(keyProvider, dataStorage)
        {
        }

        public override void LoadTracked()
        {
            base.LoadTracked();

            LanguageData = Load<LanguageData>();
            GameSceneData = Load<GameSceneData>();
            StatsData = Load<StatsData>();
            EconomyData = Load<EconomyData>();
            AudioData = Load<AudioData>();
        }

        public override void SaveTracked()
        {
            base.SaveTracked();
            
            Save(LanguageData);
            Save(GameSceneData);
            Save(StatsData);
            Save(EconomyData);
            Save(AudioData);
        }
    }
}