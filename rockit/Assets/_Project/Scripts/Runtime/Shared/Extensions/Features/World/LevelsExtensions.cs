using _Project.Scripts.Runtime.Features.World.Levels;
using _Project.Scripts.Runtime.Features.World.Levels.Services;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.World
{
    public static class LevelsExtensions
    {
        public static void Reset(this LevelsService lService)
        {
            lService.CurrLevel = null;
            lService.CurrLevelId = ProjectContracts.NullIntId;
            lService.CurrLevelDefinition = null;
        }

        public static void Reset(this LevelsStatsService lsService)
        {
            lsService.UsedTransforms = LevelsContracts.MinUsedTransforms;
        }
    }
}