using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;

namespace _Project.Scripts.Runtime.Shared.Utils.Shared
{
    public static class GameStatsUtils
    {
        public static int GetTotalStars(DataProvider dProvider)
        {
            var total = 0;

            foreach (var kvp in dProvider.GameSceneData.CompletedLevels)
            {
                total += kvp.Value.Stars;
            }
            
            return total;
        }

        public static int GetMaxStars(LevelsConfig levelsConfig)
        {
            return levelsConfig.Levels.Count * levelsConfig.MaxStarsPerLevel;
        }
    }
}