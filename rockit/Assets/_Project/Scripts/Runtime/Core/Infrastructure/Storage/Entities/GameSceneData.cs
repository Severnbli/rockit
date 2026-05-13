using System;
using System.Collections.Generic;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Storage.Entities
{
    [Serializable]
    public sealed class GameSceneData
    {
        public int LevelIdToLoad;
        public SortedDictionary<int, LevelData> CompletedLevels = new ();
    }
}