using _Project.Scripts.Modules.Zenject;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Platforms.Shared.Configs
{
    public sealed class PlatformsAreaConfig : ScriptableObjectAutoInstaller<PlatformsAreaConfig>
    {
        [SerializeField] private float _radius = 4f;
        
        public float Radius => _radius;
    }
}