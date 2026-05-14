using System.Collections.Generic;
using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Stats.Constants.Types;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Configs
{
    public sealed class ConstantsConfig : ScriptableObjectAutoInstaller<ConstantsConfig>
    {
        [SerializeField] private Dictionary<int, ConstantDefinition> _constants = new ();
        
        public Dictionary<int, ConstantDefinition> Constants => _constants;
    }
}