using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Types
{
    [Serializable]
    public sealed class LevelDefinition
    {
        public int Number;
        public GameObject Prefab;
        public string NameKey;
        public int StarsToUnlock;
    }
}