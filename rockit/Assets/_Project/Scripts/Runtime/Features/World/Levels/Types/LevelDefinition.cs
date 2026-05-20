using System;
using _Project.Scripts.Runtime.Features.Input.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Types
{
    [Serializable]
    public sealed class LevelDefinition
    {
        public GameObject Prefab;
        public string NameKey;
        public int StarsToUnlock;
        public PlatformsInputProfile PiProfile;
        public int[] StarsStages = new[] { 1 };
    }
}