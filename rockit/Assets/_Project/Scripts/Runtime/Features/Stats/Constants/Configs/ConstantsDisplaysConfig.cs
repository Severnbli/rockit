using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Stats.Constants.Configs
{
    public sealed class ConstantsDisplaysConfig : ScriptableObjectAutoInstaller<ConstantsDisplaysConfig>
    {
        [SerializeField] private float _activateDistance = 0.5f;
        
        public float ActivateDistance => _activateDistance;
    }
}