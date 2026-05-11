using System.Collections.Generic;
using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.World.Levels.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.World.Levels.Configs
{
    public sealed class LevelsConfig : ScriptableObjectAutoInstaller<LevelsConfig>
    {
        [SerializeField] private Dictionary<int, LevelDefinition> _levels = new ();
        [SerializeField] private int _maxStarsPerLevel = 3;
        
        public Dictionary<int, LevelDefinition> Levels => _levels;
        public int MaxStarsPerLevel => _maxStarsPerLevel;
    }
}