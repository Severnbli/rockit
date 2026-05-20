using _Project.Scripts.Runtime.Features.World.Levels.Monos;
using _Project.Scripts.Runtime.Features.World.Levels.Types;

namespace _Project.Scripts.Runtime.Features.World.Levels.Requests
{
    public struct LevelSpawnedRequest
    {
        public int LevelId;
        public Level Level;
        public LevelDefinition Definition;
    }
}