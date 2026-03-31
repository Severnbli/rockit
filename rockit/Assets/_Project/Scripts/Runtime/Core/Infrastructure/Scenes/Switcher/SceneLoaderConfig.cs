using _Project.Scripts.Modules.Zenject;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneLoaderConfig : ScriptableObjectAutoInstaller<SceneLoaderConfig>
    {
        [SerializeField] private bool _simulateLoading = false;
        [SerializeField, ShowIf(nameof(SimulateLoading))] private float _simulationLoadingDuration = 2f;
        
        public bool SimulateLoading => _simulateLoading;
        public float SimulationLoadingDuration => _simulationLoadingDuration;
    }
}