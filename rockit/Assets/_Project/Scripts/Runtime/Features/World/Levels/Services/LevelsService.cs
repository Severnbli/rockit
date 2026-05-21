using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Types;

namespace _Project.Scripts.Runtime.Features.World.Levels.Services
{
    public sealed class LevelsService
    {
        public int LevelIdToSpawn;
        public int CurrLevelId;
        public Level CurrLevel;
        public LevelDefinition CurrLevelDefinition;
    }
}