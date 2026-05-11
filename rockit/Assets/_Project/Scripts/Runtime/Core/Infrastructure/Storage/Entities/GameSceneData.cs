using System;
using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.World.Levels.Types;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class GameSceneData
    {
        public int LevelIdToLoad;
        public Dictionary<int, LevelData> CompletedLevels = new ();
    }
}