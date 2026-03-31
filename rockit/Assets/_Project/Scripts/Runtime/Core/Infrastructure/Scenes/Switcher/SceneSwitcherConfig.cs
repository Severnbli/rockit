using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcherConfig : ScriptableObjectAutoInstaller<SceneSwitcherConfig>
    {
        [SerializeField] private bool _simulateLoading = false;
        [SerializeField] private float _simulationLoadingDuration = 2f;
        
        public bool SimulateLoading => _simulateLoading;
        public float SimulationLoadingDuration => _simulationLoadingDuration;
    }
}