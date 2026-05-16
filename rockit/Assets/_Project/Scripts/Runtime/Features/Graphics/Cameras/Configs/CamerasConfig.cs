using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Cameras.Configs
{
    public sealed class CamerasConfig : ScriptableObjectAutoInstaller<CamerasConfig>
    {
        [SerializeField] private int _primaryCameraPriority = 10;
        [SerializeField] private int _secondaryCameraPriority = 0;
        
        public int PrimaryCameraPriority => _primaryCameraPriority;
        public int SecondaryCameraPriority => _secondaryCameraPriority;
    }
}