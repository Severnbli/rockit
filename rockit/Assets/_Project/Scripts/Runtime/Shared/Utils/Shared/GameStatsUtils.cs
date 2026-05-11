using _Project.Scripts.Runtime.Core.Infrastructure.Storage;

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
    }
}